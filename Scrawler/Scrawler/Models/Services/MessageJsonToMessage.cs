using System;
using System.Linq;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageJsonToMessage : IMessageJsonToMessage
    {
        private readonly IRepository<Chatroom> _repository = new Repository<Chatroom>();
 
        public Message MapToMessage(MessageJson msgJson)
        {            
            return new Message
            {
                Body = msgJson.Content,
                CreatedAt = DateTime.Now,
                ChatroomId = _repository.Get(x => x.HiddenUrl == msgJson.HiddenUrl).Single().Id,
                Votes = 1,
            };
        }
    }
}