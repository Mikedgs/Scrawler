using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Models.Interfaces; // TODO R# green
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    public class ChatController_Tests
    {
        // TODO change CHatController.Index so that it returns a RedirectResult not an actionResult, and then delete this test.
        [Test]
        public void The_index_method_returns_a_redirect_result()
        {
            // Arrange
            var chatRepoMock = new Mock<IRepository<Chatroom>>();
            chatRepoMock.Setup(x => x.FindById(It.IsAny<int>())).Returns(new Chatroom());
            var sut = new ChatController(chatRepoMock.Object, null, null, null, Mock.Of<IResponseProxy>());
            // Act
            var result = sut.Index(It.IsAny<int>());
            // Assert
            Assert.IsInstanceOf(typeof(RedirectResult), result);
        }

        [Test]
        public void The_room_information_returns_a_chatRoomJson()
        {
            // Arrange
            var chatRepoMock = new Mock<IRepository<Chatroom>>();
            var messageRepoMock = new Mock<IRepository<Message>>();
            var mapperMock = new Mock<IMessageMapperToJson>();            
            
            chatRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> {new Chatroom{HiddenUrl = "2"}});

            messageRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Message, bool>>>())).Returns(new List<Message>() { new Message()});
            mapperMock.Setup(x => x.MapToJson(new Message()));
            var cut = new ChatController(chatRepoMock.Object, messageRepoMock.Object, mapperMock.Object, null, Mock.Of<IResponseProxy>());

            // Act
            var result = cut.GetRoomInformation(It.IsAny<string>());
            
            // Assert
            Assert.IsInstanceOf(typeof(ChatroomJson), result.Data);
        }
    }
}
