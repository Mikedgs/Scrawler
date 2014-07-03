using System.Collections.Generic;

namespace Scrawler.Models
{
    public interface IChatroomJson
    {
        string FireBaseRoomId { get; set; }
        List<MessageJson> Messages { get; set; }
    }
}