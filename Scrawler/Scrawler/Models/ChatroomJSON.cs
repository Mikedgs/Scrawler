using System.Collections.Generic;

namespace Scrawler.Models
{
    public class ChatroomJson : IChatroomJson
    {
        public string FireBaseRoomId { get; set; }
        public List<MessageJson> Messages { get; set; }
    }
}