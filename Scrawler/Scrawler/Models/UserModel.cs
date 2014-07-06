using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class UserModel // TODO this is a straight duplicate of AdminViewModel. And it's not a viewmodel. Please to consider its functionzzzzz.
    {
        private readonly Repository<Admin> _repo;

        public UserModel()
        {
            _repo = new Repository<Admin>();
        }

        public void SaveUser(Admin user)
        {
            _repo.Add(user);
            _repo.SaveChanges();
        }

        public Admin Validate(Admin user)
        {
            var password = new HashProvider().GetMd5Hash(user.Password);
            return _repo.Get(x => x.UserName == user.UserName && x.Password == password).FirstOrDefault();
        }
    }
}