using System;
using System.Threading;
using System.Timers;
using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Services;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;
using Timer = System.Timers.Timer;

namespace Scrawler.Controllers
{
    public class ControlPanelController : ScrawlerController
    {
        private readonly IRepository<Chatroom> _chatRepository;
        private readonly IHiddenStringFactory _stringFactory;
        private Timer _timer;
        private readonly LinkUpdater _DBrefresh;

        public ControlPanelController(IResponseProxy responseProxy, IRepository<Chatroom> chatRepository, IHiddenStringFactory stringFactory, Timer timer, LinkUpdater DBrefresh) : base(responseProxy)
        {
            _chatRepository = chatRepository;
            _stringFactory = stringFactory;
            _timer = timer;
            _DBrefresh = DBrefresh;
            _timer.Interval = 1800000;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _DBrefresh.UpdateLinks();
        }

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

        public void Dispose()
        {
            _chatRepository.Dispose();
            base.Dispose();
        }
    }
}