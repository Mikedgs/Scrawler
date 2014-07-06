using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ChatController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IRepository<Message> _messageRepository;
        private readonly IMessageMapperToJson _messageMapperToJson;
        private readonly ISaveMessage _saveMessage;

        public ChatController(IRepository<Chatroom> chatRepository, IRepository<Message> messageRepository,
            IMessageMapperToJson messageMapperToJson, ISaveMessage saveMessage, IResponseProxy responseProxy)
            : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _messageMapperToJson = messageMapperToJson;
            _saveMessage = saveMessage;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return Redirect("http://hidden-falls-5768.herokuapp.com?id=" + _chatRepository.FindById(id).HiddenUrl); // TODO don't use + for string concatenation
            // TODO pull this URL out into config - don't just reference COnfigurationManager - wrap in a class and inject an IConfiguration
        }

        [HttpPost]
        public ActionResult SaveMessage(MessageJson msg)
        {
            _saveMessage.SaveMessages(msg);
            return CrossSiteFriendlyJson("Sent");
        }

        [HttpGet]
        public JsonResult GetRoomInformation(string id)
        {
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == id).First(); // TODO .FirstOrDefault - if not found, Json("Not found URL") - add that URL to config
            var listOfImmortalMsgs = _messageRepository.Get(x => x.ChatroomId == chatroom.Id).ToList();
            var sortedlistofImortalMsgs = listOfImmortalMsgs.OrderByDescending(x => x.Votes).ToList();

            var topThree = new List<Message>();

            if (listOfImmortalMsgs.Count > 2)
            {
                topThree.AddRange(sortedlistofImortalMsgs.Take(3)); // TODO takewhile to simplify all that >2 business?
            }

            var listOfConvertedJsonMsgs = topThree.Select(msg => _messageMapperToJson.MapToJson(msg)).ToList();
            var chatRoomJson = new ChatroomJson
            {
                FireBaseRoomId = chatroom.FirebaseId,
                Messages = listOfConvertedJsonMsgs,
                ChatroomName = chatroom.chatroom_name
            };
            return CrossSiteFriendlyJson(chatRoomJson);
        }
    }
}