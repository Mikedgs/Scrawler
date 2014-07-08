using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageSaver : IMessageSaver
    {
        private readonly IMessageJsonToMessageMapper _mapper;
        private readonly IRepository<Message> _repository;

        public MessageSaver(IRepository<Message> repository, IMessageJsonToMessageMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void SaveMessages(MessageJson msg) // TODO BA why is a method called SaveMessages (plural) saving one message? Why is it increasing the number of votes? Should it be called UpvoteMessage?
        {
            var messageToSave = _repository.Get(x => x.MessageId == msg.MessageId).SingleOrDefault() ??
                                    _mapper.MapToMessage(msg);
            messageToSave.Votes += 1;
            _repository.Add(messageToSave);
            _repository.SaveChanges();
        }
    }
}