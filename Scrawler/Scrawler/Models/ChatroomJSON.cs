using System.Collections.Generic;
using System.Security.Policy;

namespace Scrawler.Models
{
    public class ChatroomJson
    {
        public ChatroomJson(string fireBaseRoomId, List<MessageJson> messages, string chatroomName, string error, string url)
        {
            FireBaseRoomId = fireBaseRoomId;
            Messages = messages;
            ChatroomName = chatroomName;
            Error = error;
            Address = url;
        }

        public string FireBaseRoomId { get; private set; }
        public List<MessageJson> Messages { get; private set; }
        public string ChatroomName { get; private set; }
        public string Error { get; private set; }
        public string Address { get; private set; }
    }
}