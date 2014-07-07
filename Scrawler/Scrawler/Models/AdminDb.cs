using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class AdminDb : IAdminDb
    {
        private readonly Repository<Admin> _repo;

        public AdminDb()
        {
            _repo = new Repository<Admin>();
        }

        public void SaveUser(Admin admin)
        {
            admin.Password = new HashProvider().GetMd5Hash(admin.Password);
            _repo.Add(admin);
            _repo.SaveChanges();
        }

        public Admin Validate(Admin user) 
        {
            var password = new HashProvider().GetMd5Hash(user.Password);
            return _repo.Get(x => x.UserName == user.UserName && x.Password == password).FirstOrDefault();
        }
    }  
}