using System.Collections.Generic;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Mappers;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    class ChatRoomJsonMapperTests
    {
        [Test]
        public void that_MapRoomToJson_returns_a_chatRoomJson()
        {
            // Arrange
            var cut = new ChatRoomJsonMapper();

            // Act
            var result = cut.MapRoomToJson("id", new List<MessageJson>(), "roomName");
            
            // Assert
            Assert.That(result, Is.InstanceOf<ChatroomJson>());
        }

        [Test]
        public void that_MapRoomToJson_correctly_maps_a_room_to_Json()
        {
            // Arrange
            var cut = new ChatRoomJsonMapper();

            // Act
            var result = cut.MapRoomToJson("id", new List<MessageJson>(), "roomName");

            // Assert
            Assert.That(result.ChatroomName, Is.EqualTo("roomName"));
            Assert.That(result.FireBaseRoomId, Is.EqualTo("id"));
            Assert.That(result.Messages, Is.InstanceOf<List<MessageJson>>());
        }
    }
}
