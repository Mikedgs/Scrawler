using System.Web.Mvc;
using System.Web.Routing;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public abstract class ScrawlerController : Controller
    {
        private readonly IResponseProxy _responseProxy;
        private readonly ISessionProxy _sessionProxy;

        protected ScrawlerController(IResponseProxy responseProxy, ISessionProxy sessionProxy)
        {
            _responseProxy = responseProxy;
            _sessionProxy = sessionProxy;
        }

        protected JsonResult CrossSiteFriendlyJson(object data)
        {
            _responseProxy.AddHeader("Access-Control-Allow-Origin", "*");
            _responseProxy.AddHeader("Access-Control-Request-Methods", "*");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected ActionResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Admin", new RouteValueDictionary {{"validUser", false}});
        }

        protected ActionResult RedirectToControlPanel()
        {
            return RedirectToAction("Index", "ControlPanel");
        }

        protected void ValidateInput(Admin admin)
        {
            if (!_sessionProxy.ValidateInput(admin))
            {
                RedirectToLogin();
            }
        }

        // TODO BA rename? RedirectIfNotLoggedIn?
        protected void CheckIfLoggedIn() // TODO BA pull this out of the base class and stick it in a LoginChecker, so you can write tests like "If_the_login_checker_says_the_user_is_not_logged_in_the_secure_thing_that_shouldnt_get_called_doesnt_get_called
        {
            if (!_sessionProxy.IsLoggedIn)
            {
                RedirectToLogin().ExecuteResult(ControllerContext);
            }
        }
    }
}