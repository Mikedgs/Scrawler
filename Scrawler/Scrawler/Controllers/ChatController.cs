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
        private readonly IMessageJsonToMessage _messageJsonToMessage;
        private readonly IMessageMapperToJson _messageMapperToJson;

        public ChatController(IRepository<Chatroom> chatRepository, IRepository<Message> messageRepository, IMessageJsonToMessage messageJsonToMessage, IMessageMapperToJson messageMapperToJson)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _messageJsonToMessage = messageJsonToMessage;
            _messageMapperToJson = messageMapperToJson;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return Redirect("http://www.scrawler.heroku.com/chat?id=" + _chatRepository.FindById(id).HiddenUrl);
        }

        [HttpPost]
        public void SaveMessage(MessageJson msg)
        {
            var convertedMsg = _messageJsonToMessage.MapToMessage(msg);               
            _messageRepository.Add(convertedMsg);
            _messageRepository.SaveChanges();
        }

        [HttpGet]
        public JsonResult GetRoomInformation(string id)
        {
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == id).Single();
            var listOfImmortalMsgs = _messageRepository.Get(x => x.ChatroomId == chatroom.Id).ToList();
            var listOfConvertedJsonMsgs = listOfImmortalMsgs.Select(msg => _messageMapperToJson.MapToJson(msg)).ToList();
            var chatRoomJson = new ChatroomJson
            {
                FireBaseRoomId = chatroom.FirebaseId,
                Messages = listOfConvertedJsonMsgs
            };
            return CrossSiteFriendlyJson(chatRoomJson);
        }
    }
}