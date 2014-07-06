using System.Web.Mvc;

namespace Scrawler.Controllers
{
    public class HomeController : Controller // TODO get rid of this if it does nothing
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}