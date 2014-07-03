﻿using System;

namespace Scrawler.Models
{
    public class MessageJson : IMessageJson
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public int? Votes { get; set; }
    }
}