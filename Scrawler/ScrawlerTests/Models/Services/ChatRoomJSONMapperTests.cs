using System.Collections.Generic;
using NUnit.Framework;
using Scrawler.Models;
using Scrawler.Models.Mappers;

namespace ScrawlerTests.Models.Services
{
    [TestFixture]
    internal class ChatRoomJsonMapperTests
    {
        [Test]
        public void that_MapRoomToJson_correctly_maps_a_room_to_Json()
        {
            // Arrange
            var cut = new ChatRoomJsonMapper();

            // Act
            ChatroomJson result = cut.MapRoomToJson("id", new List<MessageJson>(), "roomName");

            // Assert
            Assert.IsInstanceOf(typeof (ChatroomJson), result);
        }

        [Test]
        public void that_MapRoomToJson_returns_a_chatRoomJson()
        {
            // Arrange
            var cut = new ChatRoomJsonMapper();

            // Act
            ChatroomJson result = cut.MapRoomToJson("id", new List<MessageJson>(), "roomName");

            // Assert
            Assert.IsInstanceOf(typeof (ChatroomJson), result);
        }
    }
}