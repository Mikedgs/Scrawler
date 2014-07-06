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
            mock.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> { new Chatroom { HiddenUrl = "2"} });
            // Hidden url constantly changes, unsure how to testt without querying the azure db
            var jsonMessage = new MessageJson() { Content = "content", RoomId = 1, Username = "username", ChatroomName = "name", HiddenUrl = "01WYI"};

            // Act
            var message = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo("content"));
            Assert.That(message.ChatroomId, Is.EqualTo(1));
        }
    }
}
