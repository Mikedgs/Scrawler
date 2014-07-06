using System.Web.Mvc;
using System.Web.Routing;
using Scrawler.Models;
using Scrawler.Plumbing;

namespace Scrawler.Controllers
{
    public class AdminController : Controller
    {
        private readonly Repository<Admin> _adminRepository = new Repository<Admin>();

        [HttpGet]
        public ActionResult Login(bool validUser = true)
        {
            return View(new LoginViewModel(new Admin(), validUser));
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            // TODO this is offensive. Pull it all out. ISessionProxy's default implementation should handle much of this
            if (admin.UserName == null || admin.Password == null)
            {
                return RedirectToAction("Login", "Admin", new RouteValueDictionary { { "validUser", false } });
            }
            var validUser = new UserModel().Validate(admin);
            if (validUser == null)
                return RedirectToAction("Login", "Admin", new RouteValueDictionary {{"validUser", false}});
            Session["loggedIn"] = "true";
            Session["UserId"] = validUser.Id;
            Session["UserName"] = validUser.UserName;
            return Redirect("/ControlPanel/index");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            var user = new Admin();
            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(Admin addNewUser)
        {
            if ((string) Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            addNewUser.Password = new HashProvider().GetMd5Hash(addNewUser.Password);
            _adminRepository.Add(addNewUser);
            _adminRepository.SaveChanges();
            Session["loggedIn"] = "true";
            Session["UserId"] = addNewUser.Id;
            return RedirectToAction("Index", "ControlPanel"); //Redirect to user page
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/ControlPanel/Index");
        }
    }
}