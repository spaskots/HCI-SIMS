using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    public class AllergenService
    {
        public AllergenRepository allergenRepository = new AllergenRepository();
        public bool Add(Allergen allergen)
        {
            if (allergenRepository.ExistsById(allergen.Id))
            {
                return false;
            }

            allergenRepository.Add(allergen);
            return true;
        }

        public void AddForPatient(string patientId, string name)
        {
            allergenRepository.AddForPatient(patientId, name);
        }

        public void DeleteByPatientId(string patientId, string name)
        {
            allergenRepository.DeleteByPatientId(patientId, name);
        }

        public List<Allergen> GetAllByPatientId(string patientId)
        {
            return allergenRepository.GetAllByPatientId(patientId);
        }

        public List<Allergen> GetAllNoRepeat(List<Allergen> patientAllergens)
        {
            List<Allergen> allAllergen = new List<Allergen>();
            allAllergen = allergenRepository.GetAll();

            allAllergen.RemoveAll(x => patientAllergens.Any(y => y.Name == x.Name)); 
            return allAllergen;
        }
    }
}
