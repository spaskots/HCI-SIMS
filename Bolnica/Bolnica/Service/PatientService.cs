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
    }
   
}
