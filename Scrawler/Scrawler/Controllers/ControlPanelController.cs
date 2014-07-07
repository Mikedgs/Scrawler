using System;
using System.Timers;
using System.Web.Mvc;
using Scrawler.Models;
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
        private readonly ISessionProxy _sessionProxy;

        public ControlPanelController(IResponseProxy responseProxy, ISessionProxy sessionProxy, IRepository<Chatroom> chatRepository,
            IHiddenStringFactory stringFactory) : base(responseProxy)
        {
            _sessionProxy = sessionProxy;
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
        }

        public ActionResult Index()
        {
            if (!_sessionProxy.CheckIfLoggedIn())
            {
                RedirectToAction("Login", "Admin");
            }
            var listofChatrooms = _chatRepository.GetAll();
            return View(listofChatrooms);
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            if (!_sessionProxy.CheckIfLoggedIn())
            {
                RedirectToAction("Login", "Admin");
            }
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            if (!_sessionProxy.CheckIfLoggedIn())
            {
                RedirectToAction("Login", "Admin");
            }
            room.HiddenUrl = _stringFactory.GenerateHiddenString();
            room.CreatedAt = DateTime.Now;

            _chatRepository.Add(room);
            _chatRepository.SaveChanges();

            return Redirect("/ControlPanel/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!_sessionProxy.CheckIfLoggedIn())
            {
                RedirectToAction("Login", "Admin");
            }      
            var room = _chatRepository.FindById(id);
            _chatRepository.Delete(room);
            _chatRepository.SaveChanges();

            return Redirect("/ControlPanel/Index");
        }

        public new void Dispose()
        {
            _chatRepository.Dispose();
            base.Dispose();
        }
    }
}