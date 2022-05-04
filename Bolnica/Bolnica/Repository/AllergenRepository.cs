using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Repository
{
    public class AllergenRepository
    {
        String ALLERGEN_FILE = @"..\..\..\Data\Allergen.txt";
        String PATIENT_ALLERGEN_FILE = @"..\..\..\Data\Patient_Allergen.txt";

        public AllergenRepository()
        {
            if (!File.Exists(ALLERGEN_FILE))
            {
                using (StreamWriter sw = File.CreateText(ALLERGEN_FILE))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(PATIENT_ALLERGEN_FILE))
            {
                using (StreamWriter sw = File.CreateText(ALLERGEN_FILE))
                {
                    sw.Write("");
                }
            }
        }

        public bool ExistsById(int id)
        {
            string[] lines = File.ReadAllLines(ALLERGEN_FILE);

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                if (line == "")
                {
                    continue;
                }
                if (fields[0] == id.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(Allergen allergen)
        {
            using (StreamWriter sw = File.AppendText(ALLERGEN_FILE))
            {
                String newText = allergen.Id + "," + allergen.Name;
                sw.WriteLine(newText);
            }
        }

        public void AddForPatient(string patientId, string name)
        {
            using (StreamWriter sw = File.AppendText(PATIENT_ALLERGEN_FILE))
            {
                String newText = patientId + "," + name;
                sw.WriteLine(newText);
            }
        }

        public void DeleteByPatientId(string patientId, string name)
        {
            String deleteRow = patientId + "," + name;

            String text = File.ReadAllText(PATIENT_ALLERGEN_FILE);

            if (text.Contains(deleteRow))
            {
                text = text.Replace(deleteRow, "");
                File.WriteAllText(PATIENT_ALLERGEN_FILE, text);
                var lines = File.ReadAllLines(PATIENT_ALLERGEN_FILE).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(PATIENT_ALLERGEN_FILE, lines);
            }
        }


        public List<Allergen> GetAllByPatientId(string patientId)
        {
            List<Allergen> allergens = new List<Allergen>();

            string[] lines = File.ReadAllLines(PATIENT_ALLERGEN_FILE);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") continue;
                if (fields[0] == patientId)
                {
                    allergens.Add(new Allergen(fields[1]));
                }
            }
            return allergens;
        }

        public List<Allergen> GetAll()
        {
            List<Allergen> allergens = new List<Allergen>();

            string[] lines = File.ReadAllLines(ALLERGEN_FILE);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") continue;
                allergens.Add(new Allergen(fields[1]));
            }

            return allergens;
        }
    }
}
