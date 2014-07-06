using System;
using System.Timers;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IHiddenStringFactory _stringFactory;
        private readonly LinkUpdater _dBrefresh;
        private readonly Timer _timer1 = new Timer();

        public ControlPanelController(IResponseProxy responseProxy, IRepository<Chatroom> chatRepository,
            IHiddenStringFactory stringFactory, Timer timer, LinkUpdater dBrefresh) : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
            _dBrefresh = dBrefresh;
            _timer1.Interval = 1800000; // TODO rip this timer out and move it into a service
            _timer1.Elapsed += _timer_Elapsed;
            _timer1.Enabled = true;
        }

        public ActionResult Index()
        {
            // TODO create an ISessionProxy sessionProxy.RedirectIfNotLoggedIn();
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Login", "Admin");
            var listofChatrooms = _chatRepository.GetAll();
            return View(listofChatrooms);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _dBrefresh.UpdateLinks();
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            room.HiddenUrl = _stringFactory.GenerateHiddenString();
            room.CreatedAt = DateTime.Now;

            _chatRepository.Add(room);
            _chatRepository.SaveChanges();

            return Redirect("/ControlPanel/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            
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