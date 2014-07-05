using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public interface IMessageJsonToMessage
    {
        Message MapToMessage(MessageJson msgJson);
    }
}