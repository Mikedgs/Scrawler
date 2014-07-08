using System.Web.Mvc;

namespace Scrawler
{
    public class FilterConfig // TODO BA is this used?
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}