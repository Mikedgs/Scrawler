using System.Linq;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;
using Scrawler.Plumbing.Interfaces;

namespace Scrawler.Models.Services
{
    public class AdminRepository : IAdminRepository 
    {
        private readonly IRepository<Admin> _repository;
        private readonly IHashProvider _hashProvider;

        public AdminRepository(IRepository<Admin> repository, IHashProvider hashProvider)
        {
            _repository = repository;
            _hashProvider = hashProvider;
        }

        public void SaveUser(Admin admin)
        {
            admin.Password = _hashProvider.GetSHA(admin.Password);
            _repository.Add(admin);
            _repository.SaveChanges();
        }

        public Admin GetAdmin(Admin admin)
        {
            var password = _hashProvider.GetSHA(admin.Password);
            return _repository.Get(x => x.UserName == admin.UserName && x.Password == password).FirstOrDefault();
        }
    }  
}