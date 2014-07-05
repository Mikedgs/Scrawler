using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class SaveMessage : ISaveMessage
    {
        private readonly Repository<Message> _repository = new Repository<Message>();
        private readonly MessageJsonToMessage _mapper = new MessageJsonToMessage();

        public void SaveMessages(MessageJson msg)
        {
            var messagetosave = _repository.FindById(msg.Id);
            messagetosave.Votes += 1;
            _repository.Add(messagetosave);
            _repository.SaveChanges();
        }
    }
}