using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public interface IAdminDb
    {
        void SaveUser(Admin admin);
        Admin Validate(Admin user);
    }
}