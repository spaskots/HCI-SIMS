using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class PatientRepository
    {
        String lokacijaPacijent = @"C:\Users\Korisnik\Desktop\SIMS Projekat\HCI-SIMS\Bolnica\Pacijent.txt";
        public List<Patient> getAllPatient()
        {
            List<Patient> pacijenti = new List<Patient>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaPacijent);
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
                string username = fields[7];
                string password = fields[8];
                City city = new City(fields[9], fields[10]);
                Patient pacijent=new Patient(name, surname, dateOFBirth, phoneNumber, email, Id, isAvailable, username, password, city); ;
                pacijenti.Add(pacijent);
            }
            return pacijenti;
        }
    }
}
