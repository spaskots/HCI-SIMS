using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Repository;
namespace Bolnica.Service
{
    public class PatientService
    {
        PatientRepository patientRepository = new PatientRepository();
        public List<Patient> getAllPatient()
        {
            return patientRepository.getAllPatient();
        }
        public List<String> getAllId()
        {
            return patientRepository.getAllId();
        }

        public bool Add(Patient patient)
        {
            if (patientRepository.ExistsById(patient.Id))
            {
                return false;
            }

            patientRepository.Add(patient);
            return true;
        }

        public bool AddGuest(Patient patient)
        {
            if (patientRepository.ExistsById(patient.Id))
            {
                return false;
            }
            patientRepository.AddGuest(patient);
            return true;
        }

        public Patient FindById(string id)
        {
            if (patientRepository.ExistsById(id))
            {
                return patientRepository.FindById(id);
            }
            return null;
        }

        public Patient FindByIdFull(string id)
        {
            if (patientRepository.ExistsById(id))
            {
                return patientRepository.FindByIdSafe(id);
            }
            return null;
        }

        public bool DeleteById(string id)
        {
            if (patientRepository.ExistsById(id))
            {
                patientRepository.DeleteById(id);
                return true;
            }
            return false;
        }

        public bool Update(Patient patient)
        {
            if (!patientRepository.ExistsById(patient.Id))
            {
                return false;
            }
            patientRepository.Update(patient);
            return true;
        }

        public List<Patient> GetAllPatients()
        {
            System.Diagnostics.Debug.Write("Service");
            List<Patient> listPatient = patientRepository.getAllPatient();
            foreach (Patient pat in listPatient)
            {
                System.Diagnostics.Debug.WriteLine("Pacijent: " + pat.Name + " " + pat.Surname + "\n");
            }
            return listPatient;
        }
    }
   
}
