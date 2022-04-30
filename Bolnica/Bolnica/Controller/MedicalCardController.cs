using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using Bolnica.Model;
namespace Bolnica.Controller
{
    public class MedicalCardController
    {
        MedicalCardService medicalCardService = new MedicalCardService();

        public void save(MedCard medicalCard)
        {
            medicalCardService.save(medicalCard);
        }
        public MedCard getOneByPatientId(String idPatient)
        {
            return medicalCardService.getOneByPatientId(idPatient);
        }
        public List<int> getAllId()
        {
            return medicalCardService.getAllId();
        }
    }
}
