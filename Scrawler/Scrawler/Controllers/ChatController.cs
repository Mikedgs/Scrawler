using System.Linq;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ChatController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IConfiguration _configuration;
        private readonly IMessageRepository _messageDb;
        private readonly IMessageSaver _messageSaver;
        private readonly IRepository<Message> _messageRepository; 

        public ChatController(IRepository<Chatroom> chatRepository, IMessageSaver messageSaver,
            IResponseProxy responseProxy, IConfiguration configuration,
            IMessageRepository messageDb, IRepository<Message> messageRepository)
            : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _messageSaver = messageSaver;
            _configuration = configuration;
            _messageDb = messageDb;
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public RedirectResult Index(int id)
        {
            return Redirect(_configuration.GetBaseUrl(_chatRepository.FindById(id).HiddenUrl));
        }

        [HttpPost]
        public JsonResult SaveMessage(MessageJson msg)
        {
            var message = _messageRepository.Get(x => x.MessageId == msg.MessageId).SingleOrDefault();
            if (message == null)
            {
                _messageSaver.SaveMessage(msg);
            }
            else
            {
                _messageSaver.UpvoteMessage(message);
            }
            return CrossSiteFriendlyJson("Sent");
        }

        [HttpGet]
        public ActionResult GetRoomInformation(string id)
        {
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == id).FirstOrDefault();
            if (chatroom == null)
            {
                return CrossSiteFriendlyRedirect(_configuration.GetSplashUrl());
            }

            var listOfConvertedJsonMsgs = _messageDb.GetTopThreeMessages(chatroom.Id);

            return
                CrossSiteFriendlyJson(new ChatroomJson(chatroom.FirebaseId, listOfConvertedJsonMsgs,
                    chatroom.chatroom_name));
        }
    }
}