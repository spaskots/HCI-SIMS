using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repository
{
    internal class CureRepository
    {
        String locationCure = @"..\..\..\Data\Cure.txt";

        public CureRepository()
        {
            if (!File.Exists(locationCure))
            {
                using (StreamWriter sw = File.CreateText(locationCure))
                {
                    sw.Write("");
                }
            }
        }
        public List<Cure> GetAllCures()
        {
            List<Cure> cures = new List<Cure>();

            string[] lines = System.IO.File.ReadAllLines(locationCure);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    int id = Convert.ToInt32(fields[0]);
                    string name = fields[1];
                    int quantity = Convert.ToInt32(fields[2]);
                    bool verificationState = Convert.ToBoolean(fields[3]);

                    Cure staticEquipment = new Cure(id, name, quantity, verificationState);
                    cures.Add(staticEquipment);
                }
            }
            return cures;
        }
        public Cure AddCure(Cure cure)
        {
            String noviRed = cure.Id + "," + cure.Name + "," + cure.Quantity;
            StreamWriter write = new StreamWriter(locationCure, true);
            write.WriteLine(noviRed);
            write.Close();
            return cure;
        }
        public Boolean Delete(Cure cure)
        {
            String obrisiRed = cure.Id + "," + cure.Name + "," + cure.Quantity + "," + cure.VerificationState;

            String text = File.ReadAllText(locationCure);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(locationCure, text);
                return true;
            }
            return false;

        }
        public Cure FindById(int id)
        {
            try
            {
                return GetAllCures().SingleOrDefault(cure => cure.Id == id);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        public Cure Update(Cure cure)
        {
            Cure oldCure = FindById(cure.Id);
            Delete(oldCure);
            AddCure(cure);
            return cure;
        }

        public int GenerateNewCureId()
        {
            List<Cure> cures = GetAllCures();
            int temp = 0;
            int maxId = 1;
            foreach (Cure cure in cures)
            {
                if (cure == null) { return 1; }
                temp = cure.Id;
                if (temp > maxId) { maxId = temp; }
            }
            maxId += 1;
            return maxId;
        }
    }
}
