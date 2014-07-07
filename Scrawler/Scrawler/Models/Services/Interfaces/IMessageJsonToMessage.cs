using Scrawler.Plumbing;

namespace Scrawler.Models.Services.Interfaces
{
    public interface IMessageJsonToMessageMapper
    {
        Message MapToMessage(MessageJson msgJson);
    }
}