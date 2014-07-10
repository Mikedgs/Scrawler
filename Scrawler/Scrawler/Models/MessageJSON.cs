using System;

namespace Scrawler.Models
{
    public class MessageJson
    {
        public MessageJson(int id, string content, DateTime time, string username, int? votes, string messageId)
        {
            Id = id;
            Content = content;
            Time = time;
            Username = username;
            MessageId = messageId;
            Votes = votes;
        }

        public MessageJson()
        {
        }

        public string FirebaseId { get; set; }
        public string MessageId { get; set; }
        public int Id { get; private set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public int? Votes { get; set; }
    }
}