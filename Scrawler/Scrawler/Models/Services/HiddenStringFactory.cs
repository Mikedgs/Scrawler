﻿using System;
using System.Linq;
using System.Security.Cryptography;
using Scrawler.Models.Services.Interfaces;

namespace Scrawler.Models.Services
{
    public class HiddenStringFactory : IHiddenStringFactory
    {
        public HiddenStringFactory()
        {
            Random = new Random(GetRandomSeed());
        }

        public Random Random { get; set; }

        public string GenerateHiddenString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(Enumerable.Repeat(chars, 10).Select(s => s[Random.Next(s.Length)]).ToArray());
            return result;
        }

        protected int GetRandomSeed() // TODO BA private, unused outside of this class. Can be a getter
        {
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                var data = new byte[16];
                randomGenerator.GetBytes(data);
                return BitConverter.ToInt32(data, 0);
            }
        }
    }
}