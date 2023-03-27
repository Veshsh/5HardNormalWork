using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _5WorkNormal.Aute
{
    internal class hash
    {
        public static string GenerateSalt()
        {
            const int SaltLength = 64;
            byte[] salt = new byte[SaltLength];
            RNGCryptoServiceProvider rngRand = new RNGCryptoServiceProvider();
            rngRand.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
        public static string CreateHash(string password, string salte)
        {
            byte[] salt = Encoding.UTF8.GetBytes(salte);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = passwordBytes.Concat(salt).ToArray();
            return Convert.ToBase64String(new SHA256Managed().ComputeHash(saltedPassword));
        }

    }
}
