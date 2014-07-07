using System.Web.Mvc;

namespace Scrawler.Plumbing.Interfaces
{
    public interface ISessionProxy
    {
        void AddToSession(string key, object value);
        bool CheckIfLoggedIn();
        bool ValidateInput(Admin admin);
        void AddAdminToSession(Admin admin);
    }


}