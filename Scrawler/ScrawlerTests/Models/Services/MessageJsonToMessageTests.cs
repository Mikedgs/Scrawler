using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Services;

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
            var jsonMessage = new MessageJson() {Content = "content", RoomId = 1, Username = "username"};

            // Act
            var message = cut.MapToMessage(jsonMessage);

            // Assert
            Assert.That(message.Body, Is.EqualTo("content"));
            Assert.That(message.ChatroomId, Is.EqualTo(1));
            Assert.That(message.Username, Is.EqualTo("username"));
        }
    }
}
