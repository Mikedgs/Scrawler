using Scrawler.Plumbing;

namespace Scrawler.Models.Services.Interfaces
{
    public interface IMessageSaver
    {
        void SaveMessage(MessageJson msg);
        void UpvoteMessage(Message msg);
    }
}