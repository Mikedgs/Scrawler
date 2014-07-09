using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Mappers.Interfaces;
using Scrawler.Models.Services;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using ScrawlerTests.Plumbing;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    internal class MessageSaverTests : UnitTestBase<MessageSaver>
    {
        private MessageJson _message;
        private Mock<IMessageFactory> _mapper;
        private Mock<IRepository<Message>> _messageRepoMock;

        [TestFixtureSetUp]
        public void setup_save_messages_tests()
        {
            // Arrange
            _message = new MessageJson(1, "content", DateTime.Now, "username", 0, "id");
            _messageRepoMock = GetMock<IRepository<Message>>();
            _mapper = GetMock<IMessageFactory>();
            _messageRepoMock.Setup(x => x.Get(It.IsAny<Expression<Func<Message, bool>>>())).Returns(new List<Message>());
            _mapper.Setup(x => x.CreateMessageFromJsonMessage(It.IsAny<MessageJson>())).Returns(new Message {Votes = 1});

            // Act
            ClassUnderTest.SaveMessage(_message);
        }

        [Test]
        public void savemessages_adds_message_to_repo()
        {
            // Assert
            _messageRepoMock.Verify(x => x.Add(It.IsAny<Message>()), Times.Once);
        }

        [Test]
        public void savemessages_still_saves_message_when_repo_returns_empty_list()
        {
            // Assert
            _messageRepoMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void savemessages_still_tries_to_map_when_repo_returns_empty_list()
        {
            // Assert
            _mapper.Verify(x => x.CreateMessageFromJsonMessage(_message), Times.Once);
        }
    }
}