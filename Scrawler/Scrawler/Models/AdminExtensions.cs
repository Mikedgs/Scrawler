using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public static class AdminExtensions
    {
        public static bool HasAllTheLoginStuffItNeeds(this Admin admin)
        {
            return admin.UserName != null && admin.Password != null;
        }
    }
}