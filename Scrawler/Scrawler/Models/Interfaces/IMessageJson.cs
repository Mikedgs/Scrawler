using System;

namespace Scrawler.Models.Interfaces
{
    public interface IMessageJson
    {
        int Id { get; set; }
        int RoomId { get; set; }
        DateTime Time { get; set; }
        string Content { get; set; }
        string Name { get; set; }
        string MessageId { get; set; }
    }
}