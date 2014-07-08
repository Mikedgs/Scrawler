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
        private readonly IMessageSaver _messageSaver;
        private readonly IConfiguration _configuration;
        private readonly IMessageRepository _messageDb;
        private readonly IChatRoomJsonMapper _chatRoomJsonMapper;
        private readonly ILinkUpdater _linkUpdater;

        public ChatController(IRepository<Chatroom> chatRepository, IMessageSaver messageSaver, IResponseProxy responseProxy, ISessionProxy sessionProxy, IConfiguration configuration, IMessageRepository messageDb, IChatRoomJsonMapper chatRoomJsonMapper, ILinkUpdater linkUpdater)
            : base(responseProxy, sessionProxy)
        {
            _chatRepository = chatRepository;
            _messageSaver = messageSaver;
            _configuration = configuration;
            _messageDb = messageDb;
            _chatRoomJsonMapper = chatRoomJsonMapper;
            _linkUpdater = linkUpdater;
        }

        [HttpGet]
        public RedirectResult Index(int id)
        {
            return Redirect(_configuration.GetBaseUrl(_chatRepository.FindById(id).HiddenUrl));
        }

        [HttpPost]
        public JsonResult SaveMessage(MessageJson msg)
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
                return Redirect(_configuration.GetBaseUrl());
            }

            var listOfConvertedJsonMsgs = _messageDb.GetTopThreeMessages(chatroom.Id);
            // _linkUpdater.UpdateLinks(id);
            return CrossSiteFriendlyJson(_chatRoomJsonMapper.MapRoomToJson(chatroom.FirebaseId, listOfConvertedJsonMsgs, chatroom.chatroom_name));
        }
    }
}