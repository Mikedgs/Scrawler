﻿using System;
using System.Linq;
using Scrawler.Models.Mappers.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Mappers
{
    public class MessageFactory : IMessageFactory
    {
        private const int InitialNumberOfVotes = 0;
        private readonly IRepository<Chatroom> _chatRoomRepository;

        public MessageFactory(IRepository<Chatroom> chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public Message CreateMessageFromJsonMessage(MessageJson msgJson)
        {
            return new Message
            {
                Username = msgJson.Username,
                Body = msgJson.Content,
                CreatedAt = DateTime.Now,
                ChatroomId = _chatRoomRepository.Get(x => x.FirebaseId == msgJson.FirebaseId).Single().Id,
                Votes = InitialNumberOfVotes,
                MessageId = msgJson.MessageId
            };
        }
    }
}