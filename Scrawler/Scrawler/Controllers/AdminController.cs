using System.Web.Mvc;
using Scrawler.Models;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public class AdminController : ScrawlerController
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ILoginChecker _loginChecker;
        private readonly ISessionProxy _sessionProxy;

        public AdminController(IAdminRepository adminDb, IResponseProxy responseProxy,  ILoginChecker loginChecker, ISessionProxy sessionProxy)
            : base(responseProxy)
        {
            _adminRepository = adminDb;
            _loginChecker = loginChecker;
            _sessionProxy = sessionProxy;
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
        public ViewResult CreateUser()
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
            return View(new Admin());
        }

        [HttpPost]
        public ActionResult CreateUser(Admin newUser)
        {
            _loginChecker.RedirectIfNotLoggedIn(this);
            _adminRepository.SaveAdmin(newUser);
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