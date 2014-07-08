using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class AdminController : ScrawlerController
    {
        private readonly ISessionProxy _sessionProxy;
        private readonly IAdminRepository _adminRepository;

        public AdminController(ISessionProxy sessionProxy, IAdminRepository adminDb, IResponseProxy responseProxy)
            : base(responseProxy,sessionProxy)
        {
            _sessionProxy = sessionProxy;
            _adminRepository = adminDb;
        }

        [HttpGet]
        public ActionResult Login(bool validUser = true)
        {
            return View(new LoginViewModel(new Admin(), validUser));
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            ValidateInput(admin);

            var validUser = _adminRepository.GetAdmin(admin);
            if (validUser == null)
            {
                RedirectToLogin();
            }

            _sessionProxy.AddAdminToSession(validUser);
            return RedirectToControlPanel();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            CheckIfLoggedIn();
            return View(new Admin());
        }

        [HttpPost]
        public ActionResult CreateUser(Admin newUser)
        {
            CheckIfLoggedIn();
            _adminRepository.SaveUser(newUser);
            _sessionProxy.AddAdminToSession(newUser);
            return RedirectToControlPanel();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToControlPanel();

        }
    }
}