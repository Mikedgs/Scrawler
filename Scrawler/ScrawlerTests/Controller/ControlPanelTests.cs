using System.Collections.Generic;
using System.Timers;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    internal class ControlPanelTests
    {
        [Test]
        public void Index_page_returns_a_list_of_all_rooms()
        {
            //Arrange
            var mockRepo = new Mock<IRepository<Chatroom>>();
            var mockTimer = new Mock<Timer>();
            var sut = new ControlPanelController(null, mockRepo.Object, null, mockTimer.Object, null);
            var listOfChatrooms = new List<Chatroom>(); // TODO camelCasePleaseOrICutOffYourEars
            mockRepo.Setup(x => x.GetAll()).Returns(listOfChatrooms);

            //Act
            var list = sut.Index();

            //Assert
            Assert.That(list, Is.EqualTo(new List<Chatroom>())); // TODO areequal - listofchats?
        }

        [Test]
        public void Add_room_post_method_calls_each_method_inside_once()
        {
            //Arrange
            var mockrepo = new Mock<IRepository<Chatroom>>();
            var mockFactory = new Mock<IHiddenStringFactory>();
            var mocktimer = new Mock<Timer>();
            var sut = new ControlPanelController(null, mockrepo.Object, mockFactory.Object, mocktimer.Object, null);
            var room = new Chatroom();

            //Act
            sut.AddRoom(room);

            //Assert
            mockFactory.Verify(x => x.GenerateHiddenString(), Times.Exactly(1));
            mockrepo.Verify(x => x.Add(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockrepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }

        [Test]
        public void Delete_room_method_calls_each_method_inside_once()
        {
            //Arrange
            var mockrepo = new Mock<IRepository<Chatroom>>();
            var mocktimer = new Mock<Timer>();
            var sut = new ControlPanelController(null, mockrepo.Object, null, mocktimer.Object, null);

            //Act
            sut.Delete(6);

            //Assert
            mockrepo.Verify(x => x.FindById(It.IsAny<int>()), Times.Exactly(1));
            mockrepo.Verify(x => x.Delete(It.IsAny<Chatroom>()), Times.Exactly(1));
            mockrepo.Verify(x => x.SaveChanges(), Times.Exactly(1));
        }
    }
}