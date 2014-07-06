using System.Collections.Generic;

namespace Scrawler.Models // TODO namespace, TODO addall properties from implementor
{
    public interface IChatroomJson
    {
        string FireBaseRoomId { get; set; }
        List<MessageJson> Messages { get; set; }
    }
}