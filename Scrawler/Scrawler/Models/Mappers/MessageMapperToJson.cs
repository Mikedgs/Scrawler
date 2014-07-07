using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;

namespace Scrawler.Models.Mappers
{
    public class MessageMapperToJson : IMessageMapperToJson
    {
        public MessageJson MapToJson(Message msg)
        {
            return new MessageJson
            {
                Id = msg.Id,
                Content = msg.Body,
                Time = msg.CreatedAt,
                Username = msg.Username,
                Votes = msg.Votes
            };
        }
    }
}