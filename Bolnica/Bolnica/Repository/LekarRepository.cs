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
        String lokacijaLekar = @"..\..\..\Data\Lekar.txt";
        String lokacijaLogIn = @"..\..\..\Data\LekarLogIn.txt";

        public void saveDoctor(Doctor doctor)
        {
            String noviRed = doctor.Name + "," + doctor.Surname + "," + doctor.DateOfBirth + "," + doctor.PhoneNumber + "," + doctor.Email + "," + doctor.Id + "," + doctor.Active + "," + doctor.Username + "," + doctor.Password + "," + doctor.city.Name + "," + doctor.city.PostalCode+","+doctor.Specialization+","+doctor.LicenseId+","+doctor.Salary+","+doctor.Room.Id;
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
                if (line == "")
                {
                    continue;
                }
                string name = fields[0];
                string surname = fields[1];
                String dateOFBirth = fields[2];
                string phoneNumber = fields[3];
                string email = fields[4];
                string Id = fields[5];
                bool isAvailable = Convert.ToBoolean(fields[6]);
                string username=fields[7];
                string password=fields[8];
                City city = new City(fields[9], fields[10]);
		String idSobe = fields[14];
                Doctor doctor=new Doctor(name, surname, dateOFBirth, phoneNumber, email, Id, isAvailable, username, password, city,idSobe); 
                doktori.Add(doctor);
            }
            return doktori;
        }
        public List<String> getAllId()
        {
            List<String> ids = new List<String>();
            string[] lines = System.IO.File.ReadAllLines(lokacijaLekar);
            foreach (String line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }
                string id = fields[5];
                ids.Add(id);
            }
            return ids;
        }
        public Doctor GetOneByUsername(String username)

        {
            string[] lines = System.IO.File.ReadAllLines(lokacijaLekar);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }
                if (fields[7] == username)
                {
                    string name = fields[0];
                    string surname = fields[1];
                    String dateOFBirth = fields[2];
                    string phoneNumber = fields[3];
                    string email = fields[4];
                    string Id = fields[5];
                    bool isAvailable = Convert.ToBoolean(fields[6]);
                    string Username = fields[7];
                    string password = fields[8];
                    City city = new City(fields[9], fields[10]);
		    String idSobe = fields[14];
                    Doctor doctor = new Doctor(name, surname, dateOFBirth, phoneNumber, email, Id, isAvailable, Username, password, city,idSobe); 
                    return doctor;
                }
            }
            return null;
        }
    }
}
