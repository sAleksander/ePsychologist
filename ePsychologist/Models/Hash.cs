using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.Models
{
    class Hash
    {
        public static string GenerateSaltedHash(string password, string salt)
        {
            try
            {
                HashAlgorithm algorithm = new SHA256Managed();

                byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
                byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

                byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];
                saltBytes.CopyTo(passwordWithSaltBytes, 0);
                passwordBytes.CopyTo(passwordWithSaltBytes, saltBytes.Length);

                byte[] hash = algorithm.ComputeHash(passwordWithSaltBytes);
                return Convert.ToBase64String(hash);
            }
            catch
            {
                throw new Exception(Properties.Literals.WrongUsernameOrPassword);
            }
        }
    }
}
