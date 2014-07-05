using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class MessageMapperToJsonTests
    {
        [Test]
        public void MessageToJson_correctly_maps_message_to_json_correctly()
        {
            // Arrange
            var cut = new MessageMapperToJson();
            var message = new Message{Body = "content", Username = "user", Id = 2, Votes = 20};

            // Act
            var convertedMessage = cut.MapToJson(message);

            // Assert
            Assert.That(convertedMessage.Content, Is.EqualTo("content"));
            Assert.That(convertedMessage.Id, Is.EqualTo(2));
            Assert.That(convertedMessage.Votes, Is.EqualTo(20));
            Assert.That(convertedMessage.Username, Is.EqualTo("user"));
        }
    }
}
