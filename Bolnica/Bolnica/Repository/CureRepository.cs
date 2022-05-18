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
        String locationCureIngredients = @"..\..\..\Data\CureIngredients.txt";

        public CureRepository()
        {
            if (!File.Exists(locationCure))
            {
                using (StreamWriter sw = File.CreateText(locationCure))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(locationCureIngredients))
            {
                using (StreamWriter sw = File.CreateText(locationCureIngredients))
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

                    Cure cure = new Cure(id, name, quantity, verificationState);
                    cures.Add(cure);
                }
            }
            return cures;
        }
        public Cure AddCure(Cure cure)
        {
            String noviRed = cure.Id + "," + cure.Name + "," + cure.Quantity + "," + "false";
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
            Cure oldCureR = FindById(cure.Id);
            String oldCure = oldCureR.Id + "," + oldCureR.Name + "," + oldCureR.Quantity + "," + oldCureR.VerificationState;
            String newCure = cure.Id + "," + cure.Name + "," + cure.Quantity + "," + cure.VerificationState;

            String text = File.ReadAllText(locationCure);
            if (text.Contains(oldCure))
            {
                text = text.Replace(oldCure, newCure);
                File.WriteAllText(locationCure, text);
            }
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
        public List<Ingredient> AddCureIngredients(int cureId, List<Ingredient> ingredients)
        {
            StreamWriter write = new StreamWriter(locationCureIngredients, true);
            foreach (Ingredient ig in ingredients)
            {
                String noviRed = cureId + "," + ig.Id;
                write.WriteLine(noviRed);
            }
            write.Close();
            return ingredients;
        }
        public List<int> ReadCureIngredientFile()
        {
            List<int> cureIngredientIds = new List<int>();

            string[] lines = System.IO.File.ReadAllLines(locationCureIngredients);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    int idCure = Convert.ToInt32(fields[0]);
                    int idIngredient = Convert.ToInt32(fields[1]);
                    cureIngredientIds.Add(idCure);
                    cureIngredientIds.Add(idIngredient);

                }
            }
            return cureIngredientIds;
        }
        IngredientRepository ingredient_repository = new IngredientRepository();
        public List<Ingredient> getAllIngredientsForChosenCure(Cure cure)
        {
            List<int> cureIngredientsIds = ReadCureIngredientFile();
            List<Ingredient> allIngredients = new List<Ingredient>();
            for(int i = 0; i < cureIngredientsIds.Count; i++)
            {
                if(i%2 == 0) { 
                    if (cure.Id == cureIngredientsIds.ElementAt(i)) //znaci id cure je jednak i treba mi njegov ingredient koji je odmah na sl pozciji.
                    {
                        allIngredients.Add(ingredient_repository.FindById(cureIngredientsIds.ElementAt(i+1)));
                    }
                }
            }
            return allIngredients;
        }
    }
}
