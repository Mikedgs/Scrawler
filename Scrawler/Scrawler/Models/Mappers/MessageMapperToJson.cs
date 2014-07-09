using Scrawler.Models.Mappers.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;

namespace Scrawler.Models.Mappers
{
    public class MessageMapperToJson : IMessageMapperToJson
    {
        public MessageJson MapToJson(Message message)
        {
            return new MessageJson(message.Id, message.Body, message.CreatedAt, message.Username, message.Votes, message.MessageId);
        }
    }
}