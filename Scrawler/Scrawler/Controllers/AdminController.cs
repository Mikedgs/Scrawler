using System.Web.Mvc;
using System.Web.Routing;
using Scrawler.Models;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISessionProxy _sessionProxy;
        private readonly IAdminDb _adminDb;

        public AdminController(ISessionProxy sessionProxy, IAdminDb adminDb)
        {
            _sessionProxy = sessionProxy;
            _adminDb = adminDb;
        }

        [HttpGet]
        public ActionResult Login(bool validUser = true)
        {
            return View(new LoginViewModel(new Admin(), validUser));
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            if (!_sessionProxy.ValidateInput(admin))
            {
                return RedirectToAction("Login", "Admin", new RouteValueDictionary { { "validUser", false } });
            }

            var validUser = _adminDb.Validate(admin);
            if (validUser == null)
            {
                return RedirectToAction("Login", "Admin", new RouteValueDictionary {{"validUser", false}});
            }

            _sessionProxy.AddAdminToSession(validUser);
            return Redirect("/ControlPanel/index");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            if (!_sessionProxy.CheckIfLoggedIn()) return RedirectToAction("Index", "ControlPanel");
            return View(new Admin());
        }

        [HttpPost]
        public ActionResult CreateUser(Admin newUser)
        {
            if (!_sessionProxy.CheckIfLoggedIn()) return RedirectToAction("Index", "ControlPanel");
            _adminDb.SaveUser(newUser);
            _sessionProxy.AddAdminToSession(newUser);
            return RedirectToAction("Index", "ControlPanel");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/ControlPanel/Index");
        }
    }
}