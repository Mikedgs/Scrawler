﻿using System;
using Scrawler.Models.Interfaces;

namespace Scrawler.Models
{
    public class MessageJson : IMessageJson
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public int? Votes { get; set; }
        public string FirebaseId { get; set; }
        public string ChatroomName { get; set; }
        public string MessageId { get; set; }
    }
}