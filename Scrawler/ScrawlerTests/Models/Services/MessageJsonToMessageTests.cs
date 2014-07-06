using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class MessageJsonToMessageTests
    {
        [Test]
        public void MsgJsonToMessage_correctly_maps_json_to_message_correctly()
        {
            // Arrange
            var cut = new MessageJsonToMessage();
            var mock = new Mock<IRepository<Chatroom>>();
            var repo = new Repository<Chatroom>();
            mock.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> { new Chatroom() });
            // Hidden url constantly changes, so unsure how to test without querying the azure db
            var jsonMessage = new MessageJson() { Content = "content", RoomId = 1, Username = "username", ChatroomName = "name", HiddenUrl = "AJRYJ" };

            // Act
            var message = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo("content"));
            Assert.That(message.ChatroomId, Is.EqualTo(1));
        }
    }
}
