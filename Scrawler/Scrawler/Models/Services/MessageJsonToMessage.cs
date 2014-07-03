using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class MessageJsonToMessage : IMessageJsonToMessage
    {
        public Message MapToMessage(MessageJson msgJson)
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