using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class LekarRepository
    {
        String lokacijaLekar = @"C:\Users\Korisnik\Desktop\Bolnica\Lekar.txt";
        String lokacijaLogIn = @"C:\Users\Korisnik\Desktop\Bolnica\LekarLogIn.txt";
        public void saveDoctor(Doctor doctor)
        {
            String noviRed = doctor.Name + "," + doctor.Surname + "," + doctor.DateOfBirth + "," + doctor.PhoneNumber + "," + doctor.Email + "," + doctor.Id + "," + doctor.Active + "," + doctor.Username + "," + doctor.Password + "," + doctor.city.Name + "," + doctor.city.PostalCode+","+doctor.Specialization+","+doctor.LicenseId+","+doctor.Salary+","+doctor.Room.Name;
            StreamWriter write = new StreamWriter(lokacijaLekar, true);
            write.WriteLine(noviRed);
            write.Close();
        }
        public void LogIn(String username,String password)
        {
            string noviRed = username + "," + password;
            StreamWriter write = new StreamWriter(lokacijaLogIn, true);
            write.WriteLine(noviRed);
            write.Close();
        }
    }
}
