using System.Collections.Generic;
using Scrawler.Models.Services.Interfaces;

namespace Scrawler.Models.Mappers
{
    public class ChatRoomJsonMapper : IChatRoomJsonMapper // TODO BA this mapping work is kind of done by the ChatroomJson's constructor now... do we need this class any more?
    {
        public ChatroomJson MapRoomToJson(string firebaseId, List<MessageJson> listOfConvertedJsonMsgs, string roomName)
        {
            return new ChatroomJson(firebaseId, listOfConvertedJsonMsgs, roomName);
        }
    }
}