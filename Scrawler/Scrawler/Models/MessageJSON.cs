using System;
using Scrawler.Models.Interfaces;

namespace Scrawler.Models
{
    public class MessageJson // TODO overloaded ctors and private setters?
    {
        public MessageJson(int id, string content, DateTime time, string username, int? votes)
        {            
            Id = id;
            Content = content;
            Time = time;
            Username = username;
            Votes = votes;
        }

        public int Id { get; private set; }      
        public DateTime Time { get; private set; }
        public string Content { get; private set; }
        public string Username { get;private set; }
        public int? Votes { get; private set; }
        public string HiddenUrl { get; private set; }
        public string ChatroomName { get; private set; }
    }
}