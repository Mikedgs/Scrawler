using System.Security.Cryptography;
using System.Text;

namespace Scrawler.Models
{
    public class HashProvider // TODO file name matches class
    {
        public string GetMd5Hash(string plaintext)
        {
            var md5Provider = new MD5CryptoServiceProvider(); // Hashing algorith
            var hasedvalue = md5Provider.ComputeHash(Encoding.Default.GetBytes(plaintext)); // takes a byte array, so convert string to byte array // TODO what is a hasedvalue?
            var str = new StringBuilder(); // used to turn the resultant byte array back to a string // TODO str. str. str. stringBuilder.
            foreach (var t in hasedvalue)
            {
                str.Append(t.ToString("x2")); // TODO add a comment explaining what this Harry Potter style x2 witchcraft does
            }
            return str.ToString();
        }
    }
}