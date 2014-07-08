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

            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>()))
                .Returns(new List<Chatroom> {new Chatroom {Id = 1}});
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);
            var jsonMessage = new MessageJson(It.IsAny<int>(), "content", new DateTime(), It.IsAny<string>(), 1,
                It.IsAny<string>());

            // Act
            Message message = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo("content"));
            Assert.That(message.Votes, Is.EqualTo(It.IsAny<int>()));
        }

        [Test]
        public void that_MapRoomToJson_correctly_maps_a_room_to_Json()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())))
                .Returns(new List<Chatroom> {new Chatroom {Id = 1}});
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);
            var jsonMessage = new MessageJson(19, "content", new DateTime(), "userName", 1, It.IsAny<string>());

            // Act
            Message result = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(result.Body, Is.EqualTo("content"));
        }

        [Test]
        public void that_MapRoomToJson_returns_a_chatRoomJson()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())))
                .Returns(new List<Chatroom> {new Chatroom {Id = 1}});
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);

            // Act
            Message result =
                cut.MapToMessage(new MessageJson(It.IsAny<int>(), "content", new DateTime(), It.IsAny<string>(), 1,
                    It.IsAny<string>()));

            // Assert
            Assert.That(result, Is.InstanceOf<Message>());
        }
    }
}