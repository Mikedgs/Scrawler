using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageSaver : IMessageSaver
    {
        private readonly IRepository<Message> _repository;
        private readonly IMessageJsonToMessageMapper _mapper;

        public MessageSaver(IRepository<Message> repository, IMessageJsonToMessageMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void SaveMessages(MessageJson msg)
        {
            var messageToSave = _repository.Get(x=>x.MessageId == msg.MessageId).SingleOrDefault() ?? _mapper.MapToMessage(msg);
            messageToSave.Votes += 1;
            _repository.Add(messageToSave);
            _repository.SaveChanges();
        }
    }
}