using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;


        public ActionResult Index()
        {
            var listofChatrooms = _chatRepository.GetAll();

            return View(listofChatrooms);
        }

        public ActionResult AddRoom()
        {
            return View();
        }
    }
}