using System;
using System.Security.Cryptography;
using System.Text;

namespace Scrawler.Models.Services
{
    public class HashProvider : IHashProvider
    {
        public string GetSHA(string plaintext)
        {
            if (plaintext == string.Empty)
            {
                throw new ArgumentException();
            }
            var shaProvider = new SHA256CryptoServiceProvider(); // Hashing algorith
            var hashedValue = shaProvider.ComputeHash(Encoding.Default.GetBytes(plaintext)); // takes a byte array, so convert string to byte array
            var stringBuilder = new StringBuilder(); // used to turn the resultant byte array back to a string
            foreach (var t in hashedValue)
            {
                stringBuilder.Append(t.ToString("x2")); //  prints the input in Hexadecimal
            }

            return stringBuilder.ToString();
        }
    }
}