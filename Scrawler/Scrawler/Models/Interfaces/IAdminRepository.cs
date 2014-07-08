using Scrawler.Plumbing;

namespace Scrawler.Models.Interfaces
{
    public interface IAdminRepository
    {
        void SaveUser(Admin admin);
        Admin GetAdmin(Admin user);
    }
}