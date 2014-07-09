using System.Web.Mvc;
using System.Web.Routing;
using Scrawler.Models;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Controllers
{
    public abstract class ScrawlerController : Controller
    {
        private readonly IResponseProxy _responseProxy;
        
        protected ScrawlerController(IResponseProxy responseProxy)
        {
            _responseProxy = responseProxy;
        }

        protected JsonResult CrossSiteFriendlyJson(object data)
        {
            _responseProxy.AddHeader("Access-Control-Allow-Origin", "*");
            _responseProxy.AddHeader("Access-Control-Request-Methods", "*");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        protected RedirectResult CrossSiteFriendlyRedirect(string url)
        {
            _responseProxy.AddHeader("Access-Control-Allow-Origin", "*");
            _responseProxy.AddHeader("Access-Control-Request-Methods", "*");
            return Redirect(url);
        }

        public ActionResult RedirectToLogin()
        {
            return RedirectToAction("Login", "Admin", new RouteValueDictionary {{"validUser", false}});
        }

        protected ActionResult RedirectToControlPanel()
        {
            return RedirectToAction("Index", "ControlPanel");
        }

        protected void ValidateInput(Admin admin)
        {
            if (!admin.HasAllTheLoginStuffItNeeds())
            {
                RedirectToLogin();
            }
        }
    }
}