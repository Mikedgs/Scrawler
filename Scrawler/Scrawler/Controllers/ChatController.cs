using System.Linq;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Plumbing;

namespace Scrawler.Controllers
{
    public class ChatController : Controller
    {
        private readonly Repository<Chatroom> _chatRepository = new Repository<Chatroom>();
        private readonly Repository<Message> _messageRepository = new Repository<Message>();
        private readonly MessageJsonToMessage _messageJsonToMessage = new MessageJsonToMessage();
        private readonly MessageMapperToJson _messageMapperToJson = new MessageMapperToJson();
        
        [HttpGet]
        public ActionResult Index(int id)
        {
            return Redirect("www.scrawler.heroku.com/chat?hashedurl=" + _chatRepository.FindById(id).HiddenUrl);
        }

        [HttpPost]
        public void SaveMessage(MessageJSON msg)
        {
            var convertedMsg = _messageJsonToMessage.MapToMessage(msg);               
            _messageRepository.Add(convertedMsg);
            _messageRepository.SaveChanges();
        }

        [HttpGet]
        public ActionResult GetRoomInformation(string hashedId)
        {
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == hashedId).Single();
            var listOfImmortalMsgs = _messageRepository.Get(x => x.ChatroomId == chatroom.Id).ToList();
            var listOfConvertedJsonMsgs = listOfImmortalMsgs.Select(msg => _messageMapperToJson.MapToJson(msg)).ToList();
            var chatRoomJson = new ChatroomJSON
            {
                FireBaseRoomId = chatroom.FirebaseId,
                Messages = listOfConvertedJsonMsgs
            };
            return Json(chatRoomJson, JsonRequestBehavior.AllowGet);
        }
    }
}