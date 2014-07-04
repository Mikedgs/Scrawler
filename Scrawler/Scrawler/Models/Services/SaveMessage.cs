using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class SaveMessage : ISaveMessage
    {
        private readonly Repository<Message> _repository = new Repository<Message>();
        private readonly MessageJsonToMessage _mapper = new MessageJsonToMessage();

        public void SaveMessages(MessageJson msg)
        {
            var convertedMsg = _mapper.MapToMessage(msg);
            _repository.Add(convertedMsg);
            _repository.SaveChanges();
        }
    }
}