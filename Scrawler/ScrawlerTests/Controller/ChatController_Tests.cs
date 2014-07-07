using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    public class ChatController_Tests : UnitTestBase<ChatController>
    {
        [Test]
        public void The_room_information_returns_a_JsonResult_when_the_chatroom_does_not_return_a_null()
        {
            // Arrange
            var chatRepoMock = GetMock<IRepository<Chatroom>>();
            var messageRepoMock = GetMock<IRepository<Message>>();
            var mapperMock = GetMock<IMessageMapperToJson>();
            
            chatRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> {new Chatroom{HiddenUrl = "2"}});
            messageRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Message, bool>>>())).Returns(new List<Message>() { new Message()});
            mapperMock.Setup(x => x.MapToJson(new Message()));

            // Act
            var result = ClassUnderTest.GetRoomInformation(It.IsAny<string>());
            
            // Assert
            Assert.IsInstanceOf(typeof(JsonResult), result);
        }
    }
}
