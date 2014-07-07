using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageSaver : IMessageSaver // TODO name implies that this is a DTO, but it's actually a service. MessageSaver?
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
            var messageToSave = _repository.Get(x=>x.Body == msg.Content).SingleOrDefault() ?? _mapper.MapToMessage(msg); // TODO messageToSave - strict lowerCamelCase
            messageToSave.Votes += 1;
            _repository.Add(messageToSave);
            _repository.SaveChanges();
        }
    }
}