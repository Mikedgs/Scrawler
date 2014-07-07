using System.Security.Cryptography;
using System.Text;

namespace Scrawler.Models
{
    public class HashProvider
    {
        public string GetMd5Hash(string plaintext)
        {
            var md5Provider = new MD5CryptoServiceProvider(); // Hashing algorith
            var hashedValue = md5Provider.ComputeHash(Encoding.Default.GetBytes(plaintext)); // takes a byte array, so convert string to byte array
            var stringBuilder = new StringBuilder(); // used to turn the resultant byte array back to a string
            foreach (var t in hashedValue)
            {
                stringBuilder.Append(t.ToString("x2")); //  prints the input in Hexadecimal
            }
            return stringBuilder.ToString();
        }
    }
}