using Scrawler.Plumbing;

namespace Scrawler.Models.Interfaces
{
    public interface IAdminDb
    {
        void SaveUser(Admin admin);
        Admin Validate(Admin user);
    }
}