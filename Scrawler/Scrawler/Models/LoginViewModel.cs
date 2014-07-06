using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class LoginViewModel
    {
        public bool IsValidUser { get; set; }
        public Admin Admin { get; set; }

        public LoginViewModel(Admin admin, bool isValidUser)
        {
            Admin = admin;
            IsValidUser = isValidUser;
        }
    }
}