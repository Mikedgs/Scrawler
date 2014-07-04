using System;

namespace Scrawler.Models.Interfaces
{
    public interface IMessageJson
    {
        int Id { get; set; }
        int RoomId { get; set; }
        DateTime Time { get; set; }
        string Content { get; set; }
        string Username { get; set; }
    }
}