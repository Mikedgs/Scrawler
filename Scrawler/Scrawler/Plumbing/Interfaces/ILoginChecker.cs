using Scrawler.Controllers;

namespace Scrawler.Plumbing.Interfaces
{
    public interface ILoginChecker
    {
        void RedirectIfNotLoggedIn(ScrawlerController controller);
    }
}