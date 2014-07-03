using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scrawler.Models
{
    public class ChatroomJSON
    {
        public string FireBaseRoomId { get; set; }
        public List<MessageJSON> Messages { get; set; }
    }
}