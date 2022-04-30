using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica
{
    public class AnamnesisService
    {
        AnamnesisRepository anamnesisRepository=new AnamnesisRepository();
        public void saveOne(Anamnesis anamnesis)
        {
            anamnesisRepository.saveOne(anamnesis);
        }
        public List<int> getAllId()
        {
            return anamnesisRepository.getAllId();
        }
        public List<Anamnesis> getAllByMedicalCard(int idMedicalCard)
        {
            return anamnesisRepository.getAllByMedicalCard(idMedicalCard);
        }
        public void update(int idAnamnesis, String description)
        {
            anamnesisRepository.update(idAnamnesis, description);
        }
        
    }
}
