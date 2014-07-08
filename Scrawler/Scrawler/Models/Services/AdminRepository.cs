using System.Linq;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IHashProvider _hashProvider;
        private readonly IRepository<Admin> _repository;

        public AdminRepository(IRepository<Admin> repository, IHashProvider hashProvider)
        {
            _repository = repository;
            _hashProvider = hashProvider;
        }

        public void SaveUser(Admin admin)
        {
            admin.Password = _hashProvider.GetSha(admin.Password);
            _repository.Add(admin);
            _repository.SaveChanges();
        }

        public Admin GetAdmin(Admin admin)
        {
            string password = _hashProvider.GetSha(admin.Password);
            return _repository.Get(x => x.UserName == admin.UserName && x.Password == password).FirstOrDefault();
        }
    }
}