using System.Collections.Generic;

namespace Scrawler.Models
{
    public class ChatroomJson : IChatroomJson // TODO could this be immutable?
    {
        public string FireBaseRoomId { get; set; }
        public List<MessageJson> Messages { get; set; }
        public string ChatroomName { get; set; }
    }
}