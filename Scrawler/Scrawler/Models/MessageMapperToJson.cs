using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class MessageMapperToJson
    {
        public MessageJSON MapToJson(Message msg)
        {
            return new MessageJSON
            {
                Content = msg.Body,
                Time = msg.CreatedAt,
                Username = msg.Username,
                Votes = msg.Votes
            };
        }
    }
}