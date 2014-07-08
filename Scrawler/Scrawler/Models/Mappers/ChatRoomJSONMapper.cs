using System.Collections.Generic;
using Scrawler.Models.Services.Interfaces;

namespace Scrawler.Models.Mappers
{
    public class ChatRoomJsonMapper : IChatRoomJsonMapper
    {
        public ChatroomJson MapRoomToJson(string firebaseId, List<MessageJson> listOfConvertedJsonMsgs, string roomName)
        {
            return new ChatroomJson(firebaseId, listOfConvertedJsonMsgs, roomName);
        }
    }
}