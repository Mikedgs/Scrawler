using System.Web;
using Scrawler.Models;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Plumbing
{
    public class SessionProxy : ISessionProxy
    {
        public void AddToSession(string key, object value)
        {
            HttpContext.Current.Session.Add(key, value);
        }

        public bool IsLoggedIn
        {
            get { return (string) HttpContext.Current.Session["loggedIn"] == "true"; }
        }

        public void AddAdminToSession(Admin admin)
        {
            AddToSession("loggedIn", "true");
            AddToSession("UserName", admin.UserName);
            AddToSession("UserId", admin.Id);
        }
    }

    
}