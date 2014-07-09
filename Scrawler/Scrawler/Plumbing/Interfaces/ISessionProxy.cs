namespace Scrawler.Plumbing.Interfaces
{
    public interface ISessionProxy
    {
        bool IsLoggedIn { get; }
        void AddToSession(string key, object value);
        void AddAdminToSession(Admin admin);
    }
}