using Scrawler.Plumbing;

namespace Scrawler.Models.Mappers.Interfaces
{
    public interface IMessageFactory
    {
        Message CreateMessageFromJsonMessage(MessageJson msgJson);
    }
}