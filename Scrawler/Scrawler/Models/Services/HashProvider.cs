using System;
using System.Security.Cryptography;
using System.Text;

namespace Scrawler.Models.Services
{
    public class HashProvider : IHashProvider
    {
        public string GetSha(string plaintext)
        {
            if (plaintext == string.Empty)
            {
                throw new ArgumentException("Cannot hash an empty string");
            }
            if (plaintext == null)
            {
                throw new ArgumentNullException();
            }

            var shaProvider = new SHA256CryptoServiceProvider(); // Hashing algorith
            var hashedValue = shaProvider.ComputeHash(Encoding.Default.GetBytes(plaintext));
                // takes a byte array, so convert string to byte array
            var stringBuilder = new StringBuilder(); // used to turn the resultant byte array back to a string
            foreach (byte t in hashedValue)
            {
                stringBuilder.Append(t.ToString("x2")); //  prints the input in Hexadecimal
            }

            return stringBuilder.ToString();
        }
    }
}