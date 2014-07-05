using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class LinkUpdater
    {
        private readonly IRepository<Chatroom> _chatRepository = new Repository<Chatroom>();
        private readonly IHiddenStringFactory _stringFactory = new HiddenStringFactory();

        public void UpdateLinks()
        {

            var allrooms = _chatRepository.GetAll();
            foreach (var room in allrooms)
            {
                room.HiddenUrl = _stringFactory.GenerateHiddenString();
                _chatRepository.Add(room);
                _chatRepository.SaveChanges();
            }
        }
    }
}