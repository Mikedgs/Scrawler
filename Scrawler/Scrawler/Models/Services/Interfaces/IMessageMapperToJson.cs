using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public interface IMessageMapperToJson
    {
        MessageJson MapToJson(Message msg);
    }
}