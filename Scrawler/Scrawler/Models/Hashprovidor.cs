using System.Security.Cryptography;
using System.Text;

namespace Scrawler.Models
{
    public class HashProvider
    {
        public string GetMd5Hash(string plaintext)
        {
            var md5Provider = new MD5CryptoServiceProvider(); // Hashing algorith
            var hasedvalue = md5Provider.ComputeHash(Encoding.Default.GetBytes(plaintext)); // takes a byte array, so convert string to byte array
            var str = new StringBuilder(); // used to turn the resultant byte array back to a string
            foreach (var t in hasedvalue)
            {
                str.Append(t.ToString("x2"));
            }
            return str.ToString();
        }
    }
}