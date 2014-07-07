using System;
using System.Linq;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Mappers
{
    public class MessageJsonToMessageMapper : IMessageJsonToMessageMapper
    {
        private readonly IRepository<Chatroom> _chatRoomRepository;
        private const int InitialNumberOfVotes = 1;

        public MessageJsonToMessageMapper(IRepository<Chatroom> chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public Message MapToMessage(MessageJson msgJson)
        {            
            return new Message
            {
                Body = msgJson.Content,
                CreatedAt = DateTime.Now,
                ChatroomId = _chatRoomRepository.Get(x => x.HiddenUrl == msgJson.HiddenUrl).Single().Id,
                Votes = InitialNumberOfVotes,
                MessageId = msgJson.MessageId
            };
        }
    }
}