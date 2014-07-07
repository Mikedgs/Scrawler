using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    internal class ControlPanelControllerTests_addRoom_scenario : UnitTestBase<ControlPanelController>
    {
        [Test]
        public void Add_room_post_method_calls_each_method_inside_once()
        {
            //Arrange
            Mock<IRepository<Chatroom>> mockRepo = GetMock<IRepository<Chatroom>>();
            Mock<IHiddenStringFactory> mockFactory = GetMock<IHiddenStringFactory>();
            Mock<ISessionProxy> sessionMock = GetMock<ISessionProxy>();

            sessionMock.Setup(x => x.AddToSession("loggedIn", "true"));

            //Act
            ClassUnderTest.AddRoom(new Chatroom());

            //Assert
            mockFactory.Verify(x => x.GenerateHiddenString(), Times.Exactly(1));
            mockRepo.Verify(x => x.Add(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockRepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }
    }

    [TestFixture]
    internal class ControlPanelControllerTests_deleteRoom_scenario : UnitTestBase<ControlPanelController>
    {
        [Test]
        public void Delete_room_method_calls_each_method_inside_once()
        {
            //Arrange
            Mock<IRepository<Chatroom>> mockRepo = GetMock<IRepository<Chatroom>>();
            Mock<ISessionProxy> sessionMock = GetMock<ISessionProxy>();

            mockRepo.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Chatroom());
            sessionMock.Setup(x => x.AddToSession("loggedIn", "true"));

            //Act
            ClassUnderTest.Delete(6);

            //Assert
            mockRepo.Verify(x => x.FindById(It.IsAny<int>()), Times.Exactly(1));
            mockRepo.Verify(x => x.Delete(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockRepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }

        [Test]
        public void Index_page_returns_a_list_of_all_rooms()
        {
            //Arrange
            Mock<IRepository<Chatroom>> mockRepo = GetMock<IRepository<Chatroom>>();

            var listOfChatrooms = new List<Chatroom>();
            mockRepo.Setup(x => x.GetAll()).Returns(listOfChatrooms);

            //Act
            ActionResult list = ClassUnderTest.Index();

            //Assert
            Assert.IsInstanceOf(typeof (ViewResult), list);
            Assert.That(list, Is.Not.Null);
        }
    }
}