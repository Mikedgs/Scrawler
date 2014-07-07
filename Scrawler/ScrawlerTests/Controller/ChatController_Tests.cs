using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Models.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    public class ChatController_Tests
    {
        [Test]
        public void The_room_information_returns_a_chatRoomJson()
        {
            // Arrange
            var chatRepoMock = new Mock<IRepository<Chatroom>>();
            var messageRepoMock = new Mock<IRepository<Message>>();
            var mapperMock = new Mock<IMessageMapperToJson>();
            var configMock = new Mock<IConfiguration>();
            var messageDbMock = new Mock<IMessageDb>();
            var chatroomMapperMock = new Mock<IChatRoomJsonMapper>();

            chatRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> { new Chatroom { HiddenUrl = "2" } });

            messageRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Message, bool>>>())).Returns(new List<Message>() { new Message() });
            mapperMock.Setup(x => x.MapToJson(new Message()));
            var cut = new ChatController(chatRepoMock.Object, null, Mock.Of<IResponseProxy>(), configMock.Object, messageDbMock.Object, chatroomMapperMock.Object);

            // Act
            var result = cut.GetRoomInformation(It.IsAny<string>());

            // Assert
            Assert.IsInstanceOf(typeof(ChatroomJson), result.Data);
        }
    }
}
