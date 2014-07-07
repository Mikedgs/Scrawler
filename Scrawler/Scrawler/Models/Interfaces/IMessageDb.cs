using System.Collections.Generic;

namespace Scrawler.Models.Interfaces
{
    public interface IMessageDb
    {
        List<MessageJson> GetTopThreeMessages(int id);
    }
}