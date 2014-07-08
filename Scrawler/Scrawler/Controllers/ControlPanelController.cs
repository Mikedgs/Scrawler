using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Scrawler.Models.Services;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IHiddenStringFactory _stringFactory;

        public ControlPanelController(IResponseProxy responseProxy, ISessionProxy sessionProxy,
            IRepository<Chatroom> chatRepository,
            IHiddenStringFactory stringFactory, LinkUpdater dBrefresh) : base(responseProxy, sessionProxy)
        {
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
        }

        public ActionResult Index()
        {
            CheckIfLoggedIn();
            var listofChatrooms = _chatRepository.GetAll();
            return View(listofChatrooms);
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            CheckIfLoggedIn();
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            CheckIfLoggedIn();
            room.HiddenUrl = _stringFactory.GenerateHiddenString();
            room.CreatedAt = DateTime.Now;

            _chatRepository.Add(room);
            _chatRepository.SaveChanges();

            return RedirectToControlPanel();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CheckIfLoggedIn();
            var room = _chatRepository.FindById(id);
            _chatRepository.Delete(room);
            _chatRepository.SaveChanges();

            return RedirectToControlPanel();
        }

        public new void Dispose()
        {
            _chatRepository.Dispose();
            base.Dispose();
        }
    }
}