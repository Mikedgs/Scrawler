namespace Scrawler.Plumbing.Interfaces
{
    public interface ISessionProxy
    {
        bool IsLoggedIn { get; }
        void AddToSession(string key, object value);
        bool ValidateInput(Admin admin);
        void AddAdminToSession(Admin admin);
    }
}