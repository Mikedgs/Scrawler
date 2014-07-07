namespace Scrawler.Plumbing.Interfaces
{
    public interface ISessionProxy
    {
        void AddToSession(string key, object value);
        bool IsLoggedIn { get; }
        bool ValidateInput(Admin admin);
        void AddAdminToSession(Admin admin);
    }


}