using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
   

    public class RegisteredUser
    {
        public String Username { set; get; }
        public String Password { set; get; }

        public RegisteredUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

    }
}
