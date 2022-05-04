using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Repository;
namespace Bolnica.Repository
{
   public class MedicalCardRepository
    {
        String lokacijaMedicinskiKarton = @"..\..\..\Data\MedicalCard.txt";
        PatientRepository patientRepository=new PatientRepository();
        public void save(MedCard medicalCard)
        {
            String noviRed = medicalCard.Id + "," + medicalCard.patient.Id;
            StreamWriter write = new StreamWriter(lokacijaMedicinskiKarton, true);
            write.WriteLine(noviRed);
            write.Close();
        }
        public MedCard getOneByPatientId(String idPatient)
        {
            string[] lines = File.ReadAllLines(lokacijaMedicinskiKarton);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") { continue; }
                if (fields[1] == idPatient)
                {
                    String idP = fields[1];
                    Patient patient=patientRepository.FindById(idP);
                   MedCard medicalCard = new MedCard(Convert.ToInt32(fields[0]),patient);
                    return medicalCard;
                }
            }
            return null;
        }
        public List<int> getAllId()
        {



            List<int> ids = new List<int>();
            ids.Clear();

            string[] lines = System.IO.File.ReadAllLines(lokacijaMedicinskiKarton);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }


                int id = Convert.ToInt32(fields[0]);
                ids.Add(id);

            }
            return ids;
        }
      
            public List<MedCard> getAllMedicalCard()
            {
                List<MedCard> medicalCard = new List<MedCard>();

                string[] lines = System.IO.File.ReadAllLines(lokacijaMedicinskiKarton);
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');
                    if (line == "")
                    {
                        continue;
                    }
                    int id= Convert.ToInt32(fields[0]);
                   
                MedCard mc = new MedCard(id);
                medicalCard.Add(mc);

                }
                return medicalCard;
            }
        }
    }

