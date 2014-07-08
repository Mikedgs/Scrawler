using System.Collections.Generic;

namespace Scrawler.Models
{
    public class ChatroomJson
    {
        public string FireBaseRoomId { get; private set; }
        public List<MessageJson> Messages { get; private set; }
        public string ChatroomName { get; private set; }

        public ChatroomJson(string fireBaseRoomId, List<MessageJson> messages, string chatroomName)
        {
            FireBaseRoomId = fireBaseRoomId;
            Messages = messages;
            ChatroomName = chatroomName;
        }
    }
}