using System.Collections.Generic;

namespace Scrawler.Models.Services.Interfaces
{
    public interface IChatRoomJsonMapper
    {
        ChatroomJson MapRoomToJson(string firebaseId, List<MessageJson> listOfConvertedJsonMsgs, string roomName);
    }
}