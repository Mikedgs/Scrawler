using System.Linq;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Interfaces;
using Scrawler.Models.Services;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ChatController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IMessageSaver _messageSaver;
        private readonly IConfiguration _configuration;
        private readonly IMessageDb _messageDb;
        private readonly IChatRoomJsonMapper _chatRoomJsonMapper;

        public ChatController(IRepository<Chatroom> chatRepository, IMessageSaver messageSaver, IResponseProxy responseProxy, IConfiguration configuration, IMessageDb messageDb, IChatRoomJsonMapper chatRoomJsonMapper)
            : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _messageSaver = messageSaver;
            _configuration = configuration;
            _messageDb = messageDb;
            _chatRoomJsonMapper = chatRoomJsonMapper;
        }

        [HttpGet]
        public RedirectResult Index(int id)
        {
            return Redirect(_configuration.GetBaseUrl(_chatRepository.FindById(id).HiddenUrl));
        }

        [HttpPost]
        public ActionResult SaveMessage(MessageJson msg)
        {
            _messageSaver.SaveMessages(msg);
            return CrossSiteFriendlyJson("Sent");
        }

        [HttpGet]
        public ActionResult GetRoomInformation(string id)
        {
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == id).FirstOrDefault();
            if (chatroom == null)
            {
                return Redirect(_configuration.GetBaseUrl(string.Empty));
            }

            var listOfConvertedJsonMsgs = _messageDb.GetTopThreeMessages(chatroom.Id);

            return CrossSiteFriendlyJson(_chatRoomJsonMapper.MapRoomToJson(chatroom.FirebaseId, listOfConvertedJsonMsgs, chatroom.chatroom_name));
        }
    }
}