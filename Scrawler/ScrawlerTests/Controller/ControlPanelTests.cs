using System.Collections.Generic;
using System.Timers;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    internal class ControlPanelTests : UnitTestBase<ControlPanelController>
    {
        [Test]
        public void Index_page_returns_a_list_of_all_rooms()
        {
            //Arrange
            var mockRepo = GetMock<IRepository<Chatroom>>();

            var listOfChatrooms = new List<Chatroom>(); 
            mockRepo.Setup(x => x.GetAll()).Returns(listOfChatrooms);

            //Act
            var list = ClassUnderTest.Index();

            //Assert
            Assert.IsInstanceOf(typeof(ViewResult), list);
            Assert.That(list, Is.Not.Null);
        }

        [Test]
        public void Add_room_post_method_calls_each_method_inside_once()
        {
            //Arrange
            var mockRepo = GetMock<IRepository<Chatroom>>();
            var mockFactory = GetMock<IHiddenStringFactory>();
            var sessionMock = GetMock<ISessionProxy>();

            sessionMock.Setup(x => x.AddToSession("loggedIn", "true"));

            //Act
            ClassUnderTest.AddRoom(new Chatroom());

            //Assert
            mockFactory.Verify(x => x.GenerateHiddenString(), Times.Exactly(1));
            mockRepo.Verify(x => x.Add(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockRepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }

        [Test]
        public void Delete_room_method_calls_each_method_inside_once()
        {
            //Arrange
            var mockRepo = GetMock<IRepository<Chatroom>>();
            var sessionMock = GetMock<ISessionProxy>();

            mockRepo.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Chatroom());
            sessionMock.Setup(x => x.AddToSession("loggedIn", "true"));

            //Act
            ClassUnderTest.Delete(6);

            //Assert
            mockRepo.Verify(x => x.FindById(It.IsAny<int>()), Times.Exactly(1));
            mockRepo.Verify(x => x.Delete(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockRepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }
    }
}