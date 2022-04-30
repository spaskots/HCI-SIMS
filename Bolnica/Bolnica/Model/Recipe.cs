using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
namespace Bolnica.Model
{
    public class RecipeR
    {
        public int id;
        public String medicine;
        public Double quantity;
        public String instruction;
        public Double howOften;
        public String startTime;

        public Patient patient;
        public RecipeR(int id, String medicine, Double quantity, String instruction, Double howOften, String startTime,String idPatient)
        {
            this.id = id;
            this.medicine = medicine;
            this.quantity = quantity;
            this.instruction = instruction;
            this.howOften = howOften;
            this.startTime = startTime;
            this.patient = findPatient(idPatient);
        }


        public MedCard medicalCard;
        public Patient findPatient(string id)
        {
            Patient patient = null;
            PatientService patientService = new PatientService();
            List<Patient> pacijenti = patientService.getAllPatient();
            foreach (Patient p in pacijenti)
            {
                if (p.Id == id)
                {
                    patient = p;
                    break;
                }
            }
            return patient;
        }

    }
}
