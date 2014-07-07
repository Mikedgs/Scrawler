using Scrawler.Plumbing;

namespace Scrawler.Models.Services.Interfaces
{
    public interface IMessageMapperToJson
    {
        MessageJson MapToJson(Message msg);
    }
}