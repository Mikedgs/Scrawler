using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class LinkUpdater : ILinkUpdater
    {
        private readonly IHiddenStringFactory _hiddenStringFactory;
        private readonly IRepository<Chatroom> _chatRepository;

        public LinkUpdater(IRepository<Chatroom> chatRepository, IHiddenStringFactory hiddenStringFactory)
        {
            _chatRepository = chatRepository;
            _hiddenStringFactory = hiddenStringFactory;
        }

        public void UpdateLinks(string id)
        {
            var room = _chatRepository.Get(x => x.HiddenUrl == id).FirstOrDefault();
            room.HiddenUrl = _hiddenStringFactory.GenerateHiddenString();
            _chatRepository.Add(room);
            _chatRepository.SaveChanges();
        }
           
    }
}