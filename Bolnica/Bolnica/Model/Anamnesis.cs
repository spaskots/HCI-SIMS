using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
namespace Bolnica.Model
{
    public class Anamnesis
    {

        public int Id { get; set; }
        public MedCard medicalCard { get; set; }
        public String Description { get; set; }
        public int IdAppointment { get; set; }
        public String Date { get; set; }

        public Anamnesis() { }
        public Anamnesis(int id, int idAppointment, String description, String date,MedCard medicalCard)
        {
            this.Id = id;
            this.Description = description;
            this.IdAppointment = idAppointment;
            this.Date = date;
            this.medicalCard = medicalCard;
        }
        public Anamnesis(int id, int idAppointment, String description, String date, int idMedCard)
        {
            this.Id = id;
            this.Description = description;
            this.IdAppointment = idAppointment;
            this.Date = date;
            this.medicalCard = findMedCard(idMedCard);
        }
        public Anamnesis(int id, int idAppointment, String description, String date)
        {
            this.Id = id;
            this.Description = description;
            this.IdAppointment = idAppointment;
            this.Date = date;
           
        }
        public MedCard findMedCard(int id)
        {
            MedCard medicalCard = null;
           MedicalCardService service = new MedicalCardService();
            List<MedCard> mcc = service.getAllMedicalCard();
            foreach (MedCard mc in mcc)
            {
                if (mc.Id==id)
                {
                    medicalCard = mc;
                    break;
                }
            }
            return medicalCard;
        }

    }
}
