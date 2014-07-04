﻿using System.Collections.Generic;
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

        public ChatController(IRepository<Chatroom> chatRepository, IRepository<Message> messageRepository, IMessageMapperToJson messageMapperToJson, ISaveMessage saveMessage, IResponseProxy responseProxy) : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _messageRepository = messageRepository;
            _messageMapperToJson = messageMapperToJson;
            _saveMessage = saveMessage;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return Redirect("http://hidden-falls-5768.herokuapp.com?id=" + _chatRepository.FindById(id).HiddenUrl);
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
            var chatroom = _chatRepository.Get(x => x.HiddenUrl == id).First();
            var listOfImmortalMsgs = _messageRepository.Get(x => x.ChatroomId == chatroom.Id).ToList();
            listOfImmortalMsgs.OrderBy(x=>x.Votes);

            var topThree = new List<Message>();
            if (listOfImmortalMsgs.Count > 3)
            {
                topThree.Add(listOfImmortalMsgs[0]);
                topThree.Add(listOfImmortalMsgs[1]);
                topThree.Add(listOfImmortalMsgs[2]);
            }
            
            var listOfConvertedJsonMsgs = topThree.Select(msg => _messageMapperToJson.MapToJson(msg)).ToList();
            var chatRoomJson = new ChatroomJson
            {
                FireBaseRoomId = chatroom.FirebaseId,
                Messages = listOfConvertedJsonMsgs
            };
            return CrossSiteFriendlyJson(chatRoomJson);
        }
    }
}