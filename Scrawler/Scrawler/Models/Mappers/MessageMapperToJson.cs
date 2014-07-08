using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;

namespace Scrawler.Models.Mappers
{
    public class MessageMapperToJson : IMessageMapperToJson
    {
        public MessageJson MapToJson(Message msg) // TODO BA msg is a food additive. message is a Message.
        {
            return new MessageJson(msg.Id, msg.Body, msg.CreatedAt, msg.Username, msg.Votes, msg.MessageId);
        }
    }
}