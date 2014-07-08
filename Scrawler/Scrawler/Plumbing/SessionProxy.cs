using System.Web;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{
    public class SessionProxy : ISessionProxy
    {
        public void AddToSession(string key, object value) // TODO BA never used outside of this class, make it private
        {
            HttpContext.Current.Session.Add(key, value);
        }

        public bool IsLoggedIn
        {
            get { return (string) HttpContext.Current.Session["loggedIn"] == "true"; }
        }

        // TODO BA this is quite a generic name. A better name would be "DoesAdminHaveUserNameAndPassword". Also, is this a concern of the SessionProxy? Move it to a better place.
        public bool ValidateInput(Admin admin)
        {
            // return admin.HasAllTheLoginStuffItNeeds();
            return admin.UserName != null && admin.Password != null;
        }

        public void AddAdminToSession(Admin admin)
        {
            AddToSession("loggedIn", "true");
            AddToSession("UserName", admin.UserName);
            AddToSession("UserId", admin.Id);
        }
    }

    //public static class AdminExtensions
    //{
    //    public static bool HasAllTheLoginStuffItNeeds(this Admin admin)
    //    {
    //        return admin.UserName != null && admin.Password != null;
    //    }
    //}
}