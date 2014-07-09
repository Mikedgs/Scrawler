using System;
using System.Web.Mvc;
using Scrawler.Models.Services.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IHiddenStringFactory _stringFactory;
        private readonly ILoginChecker _loginChecker;

        public ControlPanelController(IResponseProxy responseProxy, 
            IRepository<Chatroom> chatRepository,
            IHiddenStringFactory stringFactory, ILoginChecker loginChecker) : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
            _loginChecker = loginChecker;
        }

        public ActionResult Index()
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
            var listofChatrooms = _chatRepository.GetAll();
            return View(listofChatrooms);
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
            room.HiddenUrl = _stringFactory.GenerateHiddenString();
            room.CreatedAt = DateTime.Now;

            _chatRepository.Add(room);
            _chatRepository.SaveChanges();

            return RedirectToControlPanel();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
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