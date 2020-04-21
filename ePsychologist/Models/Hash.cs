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
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];
            saltBytes.CopyTo(passwordWithSaltBytes, 0);
            passwordBytes.CopyTo(passwordWithSaltBytes, saltBytes.Length);

            byte[] hash = algorithm.ComputeHash(passwordWithSaltBytes);
            return Convert.ToBase64String(hash);
        }

        //public bool tryLogin(string username, string password)
        //{
        //    using (var con = new MySqlConnection("host=aaaaaaaa.baaadsg;user=saaaaaak;password=2333333336;database=soaaaaaaaa2;"))
        //    {
        //        con.Open();

        //        var salt = string.Empty;

        //        using (var cmd = new MySqlCommand("Select salt From niki where user_name = @username"))
        //        {
        //            cmd.Parameters.AddWithValue("@username", username);

        //            salt = cmd.ExecuteScalar() as string;
        //        }

        //        if (string.IsNullOrEmpty(salt)) return false;

        //        var hashedPassword = GenerateSaltedHash(password, salt);

        //        using (var cmd = new MySqlCommand("Select * FROM niki WHERE user_name = @username and user_password = @password"))
        //        {
        //            cmd.Parameters.AddWithValue("@username", username);
        //            cmd.Parameters.AddWithValue("@password", hashedPassword);

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                return reader.Read();
        //            }
        //        }
        //    }
        //}
    }
}
