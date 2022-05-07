using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repository
{
    internal class IngredientRepository
    {
        String locationIngredient = @"..\..\..\Data\Ingredient.txt";

        public IngredientRepository()
        {
            if (!File.Exists(locationIngredient))
            {
                using (StreamWriter sw = File.CreateText(locationIngredient))
                {
                    sw.Write("");
                }
            }
        }
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            string[] lines = System.IO.File.ReadAllLines(locationIngredient);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    int id = Convert.ToInt32(fields[0]);
                    string name = fields[1];
                    Ingredient ingredient = new Ingredient(id, name);
                    ingredients.Add(ingredient);
                }
            }
            return ingredients;
        }
        public Ingredient AddIngredient(Ingredient ingredient)
        {
            String noviRed = ingredient.Id + "," + ingredient.Name ;
            StreamWriter write = new StreamWriter(locationIngredient, true);
            write.WriteLine(noviRed);
            write.Close();
            return ingredient;
        }
        public Boolean Delete(Ingredient ingredient)
        {
            String obrisiRed = ingredient.Id + "," + ingredient.Name ;

            String text = File.ReadAllText(locationIngredient);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(locationIngredient, text);
                return true;
            }
            return false;

        }
        public Ingredient FindById(int id)
        {
            try
            {
                return GetAllIngredients().SingleOrDefault(ingredient => ingredient.Id == id);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        public Ingredient Update(Ingredient ingredient)
        {
            Ingredient oldIngredient = FindById(ingredient.Id);
            String oldRow = oldIngredient.Id + "," + oldIngredient.Name;
            String newRow = ingredient.Id + "," + ingredient.Name;

            String text = File.ReadAllText(locationIngredient);
            if (text.Contains(oldRow))
            {
                text = text.Replace(oldRow, newRow);
                File.WriteAllText(locationIngredient, text);
            }
            return ingredient;
        }

        public int GenerateNewCureId()
        {
            List<Ingredient> ingredients = GetAllIngredients();
            int temp = 0;
            int maxId = 1;
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient == null) { return 1; }
                temp = ingredient.Id;
                if (temp > maxId) { maxId = temp; }
            }
            maxId += 1;
            return maxId;
        }
    }
}
