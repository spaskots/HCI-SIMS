using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class UserRepository
    {
        String lokacijaPrijava = @"C:\Users\Korisnik\Desktop\Bolnica\LekarLogIn.txt";
        
        
        public Boolean validate(RegisteredUser ru)
        {
            string[] lines = System.IO.File.ReadAllLines(lokacijaPrijava);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                if (line == "")
                {
                    continue;
                }
                if (ru.Username == fields[0] && ru.Password == fields[1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
