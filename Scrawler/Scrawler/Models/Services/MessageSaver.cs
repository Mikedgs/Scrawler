using System.Linq;
using Scrawler.Models.Mappers.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageSaver : IMessageSaver
    {
        private readonly IMessageFactory _mapper;
        private readonly IRepository<Message> _repository;

        public MessageSaver(IRepository<Message> repository, IMessageFactory mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void SaveMessage(MessageJson message)
        {
            var messageToSave = _mapper.CreateMessageFromJsonMessage(message);
            messageToSave.Votes += 1;
            _repository.Add(messageToSave);
            _repository.SaveChanges();
        }

        public void UpvoteMessage(Message message)
        {
            message.Votes += 1;
            _repository.Add(message);
            _repository.SaveChanges();
        }
    }
}