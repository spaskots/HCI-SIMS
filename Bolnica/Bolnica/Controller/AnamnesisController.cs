using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Service;
namespace Bolnica.Controller
{
    public class AnamnesisController
    {
        AnamnesisService anamnesisService=new AnamnesisService();
        public void saveOne(Anamnesis anamnesis)
        {
            anamnesisService.saveOne(anamnesis);
        }
        public List<int> getAllId()
        {
            return anamnesisService.getAllId();
        }
        public List<Anamnesis> getAllByMedicalCard(int idMedicalCard)
        {
            return anamnesisService.getAllByMedicalCard(idMedicalCard);
        }
        public void update(int idAnamnesis,String description)
        {
            anamnesisService.update(idAnamnesis, description);
        }
    }
}
