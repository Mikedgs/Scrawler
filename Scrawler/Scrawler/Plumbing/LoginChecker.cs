using Scrawler.Controllers;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{
    public class LoginChecker : ILoginChecker
    {
        private readonly ISessionProxy _sessionProxy;

        public LoginChecker(ISessionProxy sessionProxy)
        {
            _sessionProxy = sessionProxy;
        }

        public void RedirectIfNotLoggedIn(ScrawlerController controller)
        {
            if (!_sessionProxy.IsLoggedIn)
            {
                controller.RedirectToLogin().ExecuteResult(controller.ControllerContext);
            }
        }
    }
}