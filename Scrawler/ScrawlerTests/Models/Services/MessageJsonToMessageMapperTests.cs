using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Mappers;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    internal class MessageJsonToMessageMapperTests
    {
        [Test]
        public void MsgJsonToMessage_correctly_maps_json_to_message_correctly()
        {
            // Arrange
            const string body = "content";
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>()))
                .Returns(new List<Chatroom> {new Chatroom {Id = 1}});
            var cut = new MessageFactory(mockRepo.Object);
            var jsonMessage = new MessageJson(1, body, new DateTime(), It.IsAny<string>(), 1,
                It.IsAny<string>());

            // Act
            var message = cut.CreateMessageFromJsonMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo(body)); 
            Assert.That(message.Votes, Is.EqualTo(0));
        }

        [Test]
        public void that_MapRoomToJson_correctly_maps_a_room_to_Json()
        {
            // Arrange
            const string body = "content";
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())))
                .Returns(new List<Chatroom> {new Chatroom {Id = 1}});
            var cut = new MessageFactory(mockRepo.Object);
            var jsonMessage = new MessageJson(19, body, new DateTime(), "userName", 1, It.IsAny<string>());

            // Act
            Message result = cut.CreateMessageFromJsonMessage(jsonMessage);

            // Assert
            Assert.That(result.Body, Is.EqualTo(body));
        }
    }
}