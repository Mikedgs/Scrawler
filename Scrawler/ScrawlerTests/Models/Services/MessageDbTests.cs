using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Mappers;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class MessageDbTests
    {
        [Test]
        public void GetTopThreeMessages_handles_repo_returning_nothing()
        {
            // Arrange
            var messageList = new List<Message>();
            var mockRepo = new Mock<IRepository<Message>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Message, bool>>>()))).Returns(messageList);
            var cut = new MessageDb(mockRepo.Object, new MessageMapperToJson());

            // Act
            var result = cut.GetTopThreeMessages(1);

            // Assert
            Assert.That(result, Is.EqualTo(new List<MessageJson>()));
        }

        [Test]
        public void GetTopThreeMessages_handles_repo_returning_less_than_expected_number_of_messages()
        {
            // Arrange
            var messageList = new List<Message>() {new Message(){Body = "body"}};
            var mockRepo = new Mock<IRepository<Message>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Message, bool>>>()))).Returns(messageList);
            var cut = new MessageDb(mockRepo.Object, new MessageMapperToJson());

            // Act
            var result = cut.GetTopThreeMessages(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTopThreeMessages_correctly_maps_3_messages()
        {
            // Arrange
            var messageList = new List<Message>() { new Message() { Body = "body" }, new Message() { Body = "next" }, new Message() { Body = "last" } };
            var mockRepo = new Mock<IRepository<Message>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Message, bool>>>()))).Returns(messageList);
            var cut = new MessageDb(mockRepo.Object, new MessageMapperToJson());

            // Act
            var result = cut.GetTopThreeMessages(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetTopThreeMessages_maps_more_than_3_messages_down_to_only_return_3()
        {
            // Arrange
            var messageList = new List<Message>() { new Message() { Body = "body" }, new Message() { Body = "next" }, new Message() { Body = "middle" }, new Message() { Body = "last" } };
            var mockRepo = new Mock<IRepository<Message>>();
            mockRepo.Setup((x => x.Get(It.IsAny<Expression<Func<Message, bool>>>()))).Returns(messageList);
            var cut = new MessageDb(mockRepo.Object, new MessageMapperToJson());

            // Act
            var result = cut.GetTopThreeMessages(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}
