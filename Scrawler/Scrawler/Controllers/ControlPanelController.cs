using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository = new Repository<Chatroom>();
        private IHiddenStringFactory _stringFactory = new HiddenStringFactory();

        public ActionResult Index()
        {

            var listofChatrooms = _chatRepository.GetAll();

            return View(listofChatrooms);
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            room.HiddenUrl = _stringFactory.GenerateHiddenString();
            room.CreatedAt = DateTime.Now;

            _chatRepository.Add(room);
            _chatRepository.SaveChanges();

            return Redirect("/ControlPanel/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var room = _chatRepository.FindById(id);
            _chatRepository.Delete(room);
            _chatRepository.SaveChanges();

            return Redirect("/ControlPanel/Index");
        }
    }
}