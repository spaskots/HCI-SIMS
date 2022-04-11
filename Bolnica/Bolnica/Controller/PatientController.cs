using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
namespace Bolnica.Controller
{
    public class PatientController
    {
        PatientService patientService=new PatientService();
        public List<String> getAllId()
        {
            return patientService.getAllId();
        }
    }
}
