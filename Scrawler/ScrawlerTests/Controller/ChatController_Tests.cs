using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Scrawler.Controllers;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace ScrawlerTests.Controller
{
    [TestFixture]
    public class ChatController_Tests
    {
        [Test]
        public void The_index_method_returns_a_redirect_result()
        {
            // Arrange
            var chatMock = new Mock<Repository<Chatroom>>();
            var sut = new ChatController(chatMock.Object, null, null, null);
            // Act
            var result = sut.Index(It.IsAny<int>());
            // Assert
            Assert.IsInstanceOf(typeof(RedirectResult), result);
        }

        [Test]
        public void The_room_information_returns_a_crossjsonResult()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
