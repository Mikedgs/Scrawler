using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class MessageJsonToMessage
    {
        public Message MapToMessage(MessageJSON msgJson)
        {
            return new Message
            {
                Body = msgJson.Content,
                CreatedAt = msgJson.Time,
                Username = msgJson.Username,
                Votes = msgJson.Votes,
                ChatroomId = msgJson.RoomId
            };
        }
    }
}