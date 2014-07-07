using System;
using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageJsonToMessageMapper : IMessageJsonToMessageMapper
    {
        private readonly IRepository<Chatroom> _repository = new Repository<Chatroom>();
        private const int InitialNumberOfVotes = 1;
        public Message MapToMessage(MessageJson msgJson)
        {            
            return new Message
            {
                Body = msgJson.Content,
                CreatedAt = DateTime.Now,
                ChatroomId = _repository.Get(x => x.HiddenUrl == msgJson.HiddenUrl).Single().Id,
                Votes = InitialNumberOfVotes
            };
        }
    }
}