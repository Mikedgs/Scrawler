using System.Web.Mvc;
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
    }
}