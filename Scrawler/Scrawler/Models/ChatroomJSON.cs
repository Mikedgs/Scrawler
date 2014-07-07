using System.Collections.Generic;

namespace Scrawler.Models
{
    public class ChatroomJson
    {
        //TODO can this be imutable??
        private readonly string _fireBaseRoomId;
        private readonly List<MessageJson> _messages;
        private readonly string _chatroomName;

        public ChatroomJson(string fireBaseRoomId, List<MessageJson> messages, string chatroomName)
        {
            _fireBaseRoomId = fireBaseRoomId;
            _messages = messages;
            _chatroomName = chatroomName;
        }
    }
}