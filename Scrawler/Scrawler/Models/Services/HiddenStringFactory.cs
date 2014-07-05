﻿using System;
using System.Linq;
using Scrawler.Plumbing;

namespace Scrawler.Models.Services
{
    public class HiddenStringFactory : IHiddenStringFactory
    {
        public string GenerateHiddenString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random((int)DateTime.Now.Ticks);
            var result = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}