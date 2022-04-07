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
        String lokacijaLekar = @"C:\Users\Korisnik\Desktop\SIMS Projekat\HCI-SIMS\Bolnica\Lekar.txt";
        String lokacijaLogIn = @"C:\Users\Korisnik\Desktop\SIMS Projekat\HCI-SIMS\Bolnica\LekarLogIn.txt";
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
        public List<Doctor> getAllDoctors()
        {
            List<Doctor> doktori = new List<Doctor>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaLekar);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                string name = fields[0];
                string surname = fields[1];
                string dateOFBirth = fields[2];
                string phoneNumber = fields[3];
                string email = fields[4];
                string Id = fields[5];
                bool isAvailable = Convert.ToBoolean(fields[6]);
                string username=fields[7];
                string password=fields[8];
                City city = new City(fields[9], fields[10]);
                Doctor doctor=new Doctor(name, surname, dateOFBirth, phoneNumber, email, Id, isAvailable, username, password, city); ;
                doktori.Add(doctor);
            }
            return doktori;
        }
    }
}
