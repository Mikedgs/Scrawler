using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class LoginViewModel
    {
        public LoginViewModel(Admin admin, bool isValidUser)
        {
            Admin = admin;
            IsValidUser = isValidUser;
        }

        public bool IsValidUser { get; private set; }
        public Admin Admin { get; private set; }
    }
}