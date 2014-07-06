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
        public ActionResult Login()
        {
            return View(new Admin());
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Admin validUser = new UserModel().Validate(admin);
            if (validUser != null)
            {
                Session["loggedIn"] = "true";
                Session["UserId"] = validUser.Id;
                Session["UserName"] = validUser.UserName;
                return Redirect("/ControlPanel/index");
            }
            var rvDic = new RouteValueDictionary { { "validUser", false } };
            return RedirectToAction("Login", "Admin", rvDic);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            if (Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
            var user = new Admin();
            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(Admin addNewUser)
        {
            if (Session["loggedIn"] != "true") return RedirectToAction("Index", "ControlPanel");
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