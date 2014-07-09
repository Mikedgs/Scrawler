using Scrawler.Plumbing;

namespace Scrawler.Models.Interfaces
{
    public interface IAdminRepository
    {
        void SaveAdmin(Admin admin);
        Admin GetAdmin(Admin admin);
    }
}