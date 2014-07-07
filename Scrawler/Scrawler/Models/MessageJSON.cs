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

        public string FirebaseId { get; set; }
        public string MessageId { get; set; }
        public int Id { get; private set; }      
        public DateTime Time { get; private set; }
        public string Content { get; private set; }
        public string Username { get;private set; }
        public int? Votes { get; private set; }
    }
}