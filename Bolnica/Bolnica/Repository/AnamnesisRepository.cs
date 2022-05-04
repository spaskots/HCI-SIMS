using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica
{
    public class AnamnesisRepository
    {
        String lokacija = @"..\..\..\Data\Anamneza.txt";

        public void saveOne(Anamnesis anamnesis)
        {
            String noviRed = anamnesis.Id + "," + anamnesis.Description + "," + anamnesis.IdAppointment + "," + anamnesis.Date+","+anamnesis.medicalCard.Id;
            StreamWriter write = new StreamWriter(lokacija, true);
            write.WriteLine(noviRed);

            write.Close();
        }
        public List<int> getAllId()
        {



            List<int> ids = new List<int>();
            ids.Clear();

            string[] lines = System.IO.File.ReadAllLines(lokacija);
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
        public List<Anamnesis> getAllByMedicalCard(int idMedicalCard)
        {

            List<Anamnesis> anamnesis = new List<Anamnesis>();
            string[] lines = System.IO.File.ReadAllLines(lokacija);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (idMedicalCard == Convert.ToInt32(fields[4]))
                {
                   
                    Anamnesis a = new Anamnesis(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[2]), fields[1], fields[3] );
                    anamnesis.Add(a);
                }
            }
            return anamnesis;
        }
        public void update(int idAnamnesis, String description)
        {
            Anamnesis stari = this.GetOne(idAnamnesis);
            String stariRed = stari.Id + "," + stari.Description + "," + stari.IdAppointment + "," + stari.Date + "," + stari.medicalCard.Id;
            DateTime today = DateTime.Today;
            String noviRed = stari.Id + "," + description + "," + stari.IdAppointment + "," + today.ToString() + "," + stari.medicalCard.Id;
            string[] lines = System.IO.File.ReadAllLines(lokacija);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == stariRed)
                {
                    lines[i] = noviRed;
                    break;
                }
            }
            File.WriteAllLines(lokacija, lines.ToArray());
        }
        
        public Anamnesis GetOne(int id)
        {

            Anamnesis anamnesis = null;
            string[] lines = System.IO.File.ReadAllLines(lokacija);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (id == Convert.ToInt32(fields[0]))
                {
                    anamnesis = new Anamnesis(Convert.ToInt32(fields[0]), Convert.ToInt32(fields[2]), fields[1], fields[3],Convert.ToInt32(fields[4]));
                    return anamnesis;
                }
            }
            return anamnesis;
        }
        public List<Anamnesis> getAllAnamnesis()
        {
            List<Anamnesis> anamnesis = new List<Anamnesis>();

            string[] lines = System.IO.File.ReadAllLines(lokacija);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }
               int id= Convert.ToInt32(fields[0]);
                String description=fields[1];
                int idAppointment=Convert.ToInt32(fields[2]);
                String date = fields[3];
                int idMedicalCard=Convert.ToInt32(fields[4]);
                Anamnesis a=new Anamnesis(id,idAppointment, description, date, idMedicalCard);
                anamnesis.Add(a);
            }
            return anamnesis;
        }
    }
}
