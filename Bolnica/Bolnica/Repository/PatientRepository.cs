using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class PatientRepository
    {

        //String PATIENT_FILE = @"D:\Workspace\Uni\6.semestar\SiMS\GitRepo\Tmp\HCI-SIMS\Bolnica\Pacijent.txt";
        String PATIENT_FILE = @"..\..\..\Data\Patient.txt";
        String GUEST_FILE = @"..\..\..\Data\Guest.txt";

        public PatientRepository()
        {
            if (!File.Exists(PATIENT_FILE))
            {
                using (StreamWriter sw = File.CreateText(PATIENT_FILE))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(GUEST_FILE))
            {
                using (StreamWriter sw = File.CreateText(GUEST_FILE))
                {
                    sw.Write("");
                }
            }
        }

        public bool ExistsById(string id)
        {
            string[] lines = File.ReadAllLines(PATIENT_FILE);
            string[] guest = File.ReadAllLines(GUEST_FILE);
            
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                
                if (line == "")
                {
                    continue;
                }
                if (fields[0] == id)
                {
                    return true;
                }
            }
            foreach (string line in guest)
            {
                string[] fields = line.Split(',');

                if (line == "")
                {
                    continue;
                }
                if (fields[0] == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Patient FindById(string id)
        {
            string[] lines = File.ReadAllLines(PATIENT_FILE);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") { continue; }
                if (fields[0] == id)
                {
                    City city = new City(fields[9], fields[12]);
                    Country country = new Country(fields[10], fields[11]);
                    city.SetCountry(country);

                    Patient patient = new Patient(fields[1], fields[2], fields[3], fields[4], fields[5], fields[0], city);
                    return patient;
                }
            }
            return null;
        }

        public void AddGuest(Patient patient)
        {
            using (StreamWriter sw = File.AppendText(GUEST_FILE)) {
                String newText = patient.Id + "," + patient.Name + "," + patient.Surname;
                sw.WriteLine(newText);
            }
        }

        public void Add(Patient patient)
        {
            using (StreamWriter sw = File.AppendText(PATIENT_FILE))
            {
                string country = patient.city.GetCountry().Name;
                string code = patient.city.GetCountry().Code;
                String newText = patient.Id + "," + patient.Name + "," + patient.Surname + "," + patient.DateOfBirth + "," +
                                 patient.PhoneNumber + "," + patient.Email + "," + patient.Username + "," + patient.Password +
                                 "," + patient.Active + "," + patient.city.Name + "," + country + "," + code + "," + patient.city.PostalCode;
                sw.WriteLine(newText);
            }
        }

        public Patient FindByIdSafe(string id)
        {
            string[] lines = File.ReadAllLines(PATIENT_FILE);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") { continue; }
                if (fields[0] == id)
                {
                    City city = new City(fields[9], fields[12]);
                    Country country = new Country(fields[10], fields[11]);
                    city.SetCountry(country);

                    bool active = bool.Parse(fields[8]);
                    Patient patient = new Patient(fields[1], fields[2], fields[3], fields[4], fields[5], fields[0], 
                                                  active, fields[6], fields[7], city);
                    return patient;
                }
            }
            return null;
        }


        public void DeleteById(string id)
        {
            Patient patient = FindByIdSafe(id);
            string country = patient.city.GetCountry().Name;
            string code = patient.city.GetCountry().Code;
            String deleteRow = patient.Id + "," + patient.Name + "," + patient.Surname + "," + patient.DateOfBirth + "," +
                               patient.PhoneNumber + "," + patient.Email + "," + patient.Username + "," + patient.Password +
                               "," + patient.Active + "," + patient.city.Name + "," + country + "," + code + "," + patient.city.PostalCode;
            String text = File.ReadAllText(PATIENT_FILE);

            if (text.Contains(deleteRow))
            {
                text = text.Replace(deleteRow, "");
                File.WriteAllText(PATIENT_FILE, text);
                var lines = File.ReadAllLines(PATIENT_FILE).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(PATIENT_FILE, lines);
            }

        }

        public void Update(Patient patient)
        {
            Patient currentPatient = FindByIdSafe(patient.Id);
            if (currentPatient == null)
            {
                return;
            }
            string oldcountry = currentPatient.city.GetCountry().Name;
            string oldcode = currentPatient.city.GetCountry().Code;

            string country = currentPatient.city.GetCountry().Name;
            string code = currentPatient.city.GetCountry().Code;

            System.Diagnostics.Debug.WriteLine("v2Email: " + patient.Email + "\nPhone: " + patient.PhoneNumber);

            String oldRow = currentPatient.Id + "," + currentPatient.Name + "," + currentPatient.Surname + "," + currentPatient.DateOfBirth + "," +
                              currentPatient.PhoneNumber + "," + currentPatient.Email + "," + currentPatient.Username + "," + currentPatient.Password +
                              "," + currentPatient.Active + "," + currentPatient.city.Name + "," + oldcountry + "," + oldcode + "," + currentPatient.city.PostalCode;


            String updateRow = patient.Id + "," + patient.Name + "," + patient.Surname + "," + patient.DateOfBirth + "," +
                               patient.PhoneNumber + "," + patient.Email + "," + patient.Username + "," + patient.Password +
                               "," + patient.Active + "," + patient.city.Name + "," + country + "," + code + "," + currentPatient.city.PostalCode;
            String text = File.ReadAllText(PATIENT_FILE);
            System.Diagnostics.Debug.WriteLine("Before entered.");
            if (text.Contains(oldRow))
            {
                System.Diagnostics.Debug.WriteLine("Entered");
                text = text.Replace(oldRow, updateRow);
                File.WriteAllText(PATIENT_FILE, text);
            }
        }

        public List<Patient> getAllPatient()
        {
            List<Patient> patients = new List<Patient>();

            string[] lines = System.IO.File.ReadAllLines(PATIENT_FILE);
            foreach (string line in lines)
            {
                if (line == "") { continue; }
                string[] fields = line.Split(',');

                City city = new City(fields[9], fields[12]);
                Country country = new Country(fields[10], fields[11]);
                city.SetCountry(country);

                bool active = bool.Parse(fields[8]);
                patients.Add(new Patient(fields[1], fields[2], fields[3], fields[4], fields[5], fields[0],
                                              active, fields[6], fields[7], city));
            }

//            if (patients.Count > 0)
            return patients;
        }
        public List<String> getAllId()
        {
            List<String> ids = new List<String>();
            string[] lines = System.IO.File.ReadAllLines(PATIENT_FILE);
            foreach (String line in lines)
            {
                string[] fields = line.Split(',');
                string id = fields[0];
                ids.Add(id);
            }
            return ids;
        }
    }
}
