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
        private readonly LinkUpdater _dBrefresh;
        private readonly Timer _timer1 = new Timer();
        private readonly ISessionProxy _sessionProxy;

        public ControlPanelController(IResponseProxy responseProxy, ISessionProxy sessionProxy, IRepository<Chatroom> chatRepository,
            IHiddenStringFactory stringFactory, LinkUpdater dBrefresh) : base(responseProxy)
        {
            _sessionProxy = sessionProxy;
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
            _dBrefresh = dBrefresh;
            _timer1.Interval = 1800000; // TODO rip this timer out and move it into a service
            _timer1.Elapsed += _timer_Elapsed;
            _timer1.Enabled = false;
        }

        public ActionResult Index()
        {
            if (!_sessionProxy.IsLoggedIn)
            {
                RedirectToAction("Login", "Admin"); // TODO see AdminController - can this be a common method on the base controller used by both?
            }
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
            if (!_sessionProxy.IsLoggedIn)
            {
                RedirectToAction("Login", "Admin");
            }
            var room = new Chatroom();
            return View(room);
        }

        [HttpPost]
        public ActionResult AddRoom(Chatroom room)
        {
            if (!_sessionProxy.IsLoggedIn)
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
            if (!_sessionProxy.IsLoggedIn)
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