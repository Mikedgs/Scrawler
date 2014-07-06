using System;
using System.Linq;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageJsonToMessage : IMessageJsonToMessage // TODO this is a mapper, call it xxxxxMapper?
    {
        private readonly IRepository<Chatroom> _repository = new Repository<Chatroom>();
 
        public Message MapToMessage(MessageJson msgJson)
        {            
            return new Message
            {
                Body = msgJson.Content,
                CreatedAt = DateTime.Now,
                ChatroomId = _repository.Get(x => x.HiddenUrl == msgJson.HiddenUrl).Single().Id,
                Votes = 1, // TODO what is this magic number? Give it a name and make it a const - eg; "InitialNumberOfVotes = 1"
            };
        }
    }
}