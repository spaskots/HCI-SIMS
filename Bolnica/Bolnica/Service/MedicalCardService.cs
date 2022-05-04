using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica.Service
{
    public class MedicalCardService
    {
        MedicalCardRepository medicalCardRepository = new MedicalCardRepository();
        
        public void save(MedCard medicalCard)
        {
            medicalCardRepository.save(medicalCard);
        }
        public MedCard getOneByPatientId(String idPatient)
        {
            return medicalCardRepository.getOneByPatientId(idPatient);
        }
        public List<int> getAllId()
        {
            return medicalCardRepository.getAllId();
        }
        public List<MedCard> getAllMedicalCard()
        {
            return medicalCardRepository.getAllMedicalCard();
        }
    }
}
