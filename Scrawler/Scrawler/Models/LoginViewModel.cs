using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class LoginViewModel
    {
        public bool IsValidUser { get; private set; } 
        public Admin Admin { get; private set; }

        public LoginViewModel(Admin admin, bool isValidUser)
        {
            Admin = admin;
            IsValidUser = isValidUser;
        }
    }
}