using System.Linq;
using Scrawler.Models.Interfaces;
using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    // TODO AdminRepository
    public class AdminDb : IAdminDb // TODO WTF is an "adminDb"? If it's a database, what's that validate method doing in there?
    {
        private readonly Repository<Admin> _repo;

        public AdminDb()
        {
            _repo = new Repository<Admin>();
        }

        public void SaveUser(Admin admin)
        {
            admin.Password = new HashProvider().GetMd5Hash(admin.Password); // TODO why are you newing this up rather than injecting it?
            _repo.Add(admin);
            _repo.SaveChanges();
        }

        public Admin Validate(Admin user) // TODO eh? Validate should return a bool, I would think. GetAdmin?
        {
            var password = new HashProvider().GetMd5Hash(user.Password);
            return _repo.Get(x => x.UserName == user.UserName && x.Password == password).FirstOrDefault();
        }
    }  
}