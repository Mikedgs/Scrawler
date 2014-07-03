﻿using System;
using System.Linq;

namespace Scrawler.Models
{
    public class HiddenStringFactory
    {

        public string GenerateHiddenString()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
            return result;
        }
    }
}