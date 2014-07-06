using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class SaveMessage : ISaveMessage // TODO name implies that this is a DTO, but it's actually a service. MessageSaver?
    {
        private readonly Repository<Message> _repository = new Repository<Message>(); // TODO add to constructor and let Ninject create these
        private readonly MessageJsonToMessage _mapper = new MessageJsonToMessage();

        public void SaveMessages(MessageJson msg)
        {
            var messagetosave = _repository.Get(x=>x.Body == msg.Content).SingleOrDefault(); // TODO messageToSave - strict lowerCamelCase
            if (messagetosave == null)
            {
                messagetosave = _mapper.MapToMessage(msg);
            }
            messagetosave.Votes += 1;
            _repository.Add(messagetosave);
            _repository.SaveChanges();
        }
    }
}