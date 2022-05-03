using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using Bolnica.Model;

namespace Bolnica.Controller
{
    public class AllergenController
    {
        public AllergenService allergenService = new AllergenService();
        public bool Add(Allergen allergen)
        {
            return allergenService.Add(allergen);
        }

        public void AddForPatient(string patientId, string name)
        {
            allergenService.AddForPatient(patientId, name);
        }

        public void DeleteByPatientId(string patientId, string name)
        {
            allergenService.DeleteByPatientId(patientId, name);
        }

        public List<Allergen> GetAllByPatientId(string patientId)
        {
            return allergenService.GetAllByPatientId(patientId);
        }

        public List<Allergen> GetAllNoRepeat(List<Allergen> patientAllergens)
        {
            return allergenService.GetAllNoRepeat(patientAllergens);
        }
    }
}
