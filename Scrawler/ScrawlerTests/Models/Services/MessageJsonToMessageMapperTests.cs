﻿using System;
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
    class MessageJsonToMessageMapperTests
    {
        [Test]
        public void that_MapRoomToJson_returns_a_chatRoomJson()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>()))).Returns(new List<Chatroom>() { new Chatroom(){Id = 1}});
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);

            // Act
            var result = cut.MapToMessage(new MessageJson(It.IsAny<int>(),"content", new DateTime(),It.IsAny<string>(), 1 ));

            // Assert
            Assert.That(result, Is.InstanceOf<Message>());
        }

        [Test]
        public void that_MapRoomToJson_correctly_maps_a_room_to_Json()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>()))).Returns(new List<Chatroom>() { new Chatroom() { Id = 1 } });
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);
            var jsonMessage = new MessageJson(19,"content", new DateTime(),"userName", 1 );

            // Act
            var result = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(result.Body, Is.EqualTo("content"));
        }

        [Test]
        public void MsgJsonToMessage_correctly_maps_json_to_message_correctly()
        {
            // Arrange
            
            var mockRepo = new Mock<IRepository<Chatroom>>();
            mockRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Chatroom, bool>>>())).Returns(new List<Chatroom> { new Chatroom() { Id = 1 } });
            var cut = new MessageJsonToMessageMapper(mockRepo.Object);
            var jsonMessage = new MessageJson(It.IsAny<int>(), "content", new DateTime(), It.IsAny<string>(), 1);

            // Act
            var message = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo("content"));
            Assert.That(message.Votes, Is.EqualTo(It.IsAny<int>()));
        }
    }
}
