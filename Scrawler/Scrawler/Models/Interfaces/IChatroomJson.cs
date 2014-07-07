using System.Collections.Generic;

namespace Scrawler.Models // TODO namespace, TODO addall properties from implementor, TODO turn on error list and look at the TODOs, TODO make sure you've done all the TODOs before asking for a code review
{
    public interface IChatroomJson
    {
        string FireBaseRoomId { get; set; }
        List<MessageJson> Messages { get; set; }
    }
}