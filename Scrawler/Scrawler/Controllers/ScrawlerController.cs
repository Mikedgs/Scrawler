using System.Web.Mvc;
using Scrawler.Models;

namespace Scrawler.Controllers
{
    public abstract class ScrawlerController : Controller
    {
        private readonly IResponseProxy _responseProxy;

        protected ScrawlerController() : this(new ResponseProxy())
        {
        }

        protected ScrawlerController(IResponseProxy responseProxy)
        {
            _responseProxy = responseProxy;
        }

        protected JsonResult CrossSiteFriendlyJson(object data)
        {
            _responseProxy.AddHeader("Access-Control-Allow-Origin", "http://hidden-falls-5768.herokuapp.com");
            _responseProxy.AddHeader("Access-Control-Request-Methods", "*");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}