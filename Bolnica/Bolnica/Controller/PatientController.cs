using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using Bolnica.Model;
namespace Bolnica.Controller
{
    public class PatientController
    {
        PatientService patientService=new PatientService();

        public bool Add(Patient patient)
        {
            return patientService.Add(patient);
        }

        public bool AddGuest(Patient patient)
        {
            return patientService.AddGuest(patient);
        }

        public Patient FindById(string id)
        {
            return patientService.FindById(id);
        }

        public Patient FindByIdFull(string id)
        {
            return patientService.FindByIdFull(id);
        }

        public bool DeleteById(string id)
        {
            return patientService.DeleteById(id);
        }

        public bool Update(Patient patient)
        {
            return patientService.Update(patient);
        }

        public List<Patient> getAllPatients()
        {
            System.Diagnostics.Debug.Write("Kontroler");
            return patientService.GetAllPatients();
        }

        public List<String> getAllId()
        {
            return patientService.getAllId();
        }
    }
}
