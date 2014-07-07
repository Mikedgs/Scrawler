using System.Collections.Generic;

namespace Scrawler.Models.Interfaces
{
    public interface IMessageRepository
    {
        List<MessageJson> GetTopThreeMessages(int chatroomId);
    }
}