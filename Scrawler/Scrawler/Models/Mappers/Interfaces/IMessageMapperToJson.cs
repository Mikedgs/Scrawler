using Scrawler.Plumbing;

namespace Scrawler.Models.Mappers.Interfaces
{
    public interface IMessageMapperToJson
    {
        MessageJson MapToJson(Message msg);
    }
}