﻿using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models
{
    public class AdminViewModel
    {
        private readonly Repository<Admin> _repo;

        public AdminViewModel()
        {
            _repo = new Repository<Admin>();
        }

        public void SaveUser(Admin admin)
        {
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