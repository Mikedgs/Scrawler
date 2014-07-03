using System;

namespace Scrawler.Models
{
    public interface IMessageJson
    {
        int Id { get; set; }
        int RoomId { get; set; }
        DateTime Time { get; set; }
        string Content { get; set; }
        string Username { get; set; }
        int? Votes { get; set; }
    }
}