using System.Collections.Generic;
using System.Linq;
using Scrawler.Models.Interfaces;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IMessageMapperToJson _messageMapperToJson;

        public MessageRepository(IRepository<Message> messageRepository, IMessageMapperToJson messageMapperToJson)
        {
            _messageRepository = messageRepository;
            _messageMapperToJson = messageMapperToJson;
        }

        public List<MessageJson> GetTopThreeMessages(int chatroomId)
        {
            var listOfImmortalMsgs = _messageRepository.Get(x => x.ChatroomId == chatroomId).ToList();
            var sortedlistofImortalMsgs = listOfImmortalMsgs.OrderByDescending(x => x.Votes).ToList();
            var topThree = sortedlistofImortalMsgs.Take(3).ToList();
            return topThree.Select(msg => _messageMapperToJson.MapToJson(msg)).ToList();
        } 
    }
}