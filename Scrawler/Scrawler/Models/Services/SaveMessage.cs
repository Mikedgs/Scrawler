using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class SaveMessage : ISaveMessage
    {
        private readonly Repository<Message> _repository = new Repository<Message>();
        private readonly MessageJsonToMessage _mapper = new MessageJsonToMessage();

        public void SaveMessages(MessageJson msg)
        {
            var messagetosave = _repository.Get(x=>x.Body == msg.Content).SingleOrDefault();
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