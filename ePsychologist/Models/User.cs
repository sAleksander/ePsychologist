using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ePsychologist.Models
{
    public class User
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }

        public User() { }
        public User(string username, SecureString password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
