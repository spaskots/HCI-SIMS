using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class RecipeRepository
    {
        String lokacija = @"..\..\..\Data\Recipe.txt";
        public void save(RecipeR recipe)
        {
            String noviRed = recipe.id + "," + recipe.medicine + "," + recipe.quantity + "," + recipe.instruction + "," + recipe.howOften + "," + recipe.startTime + "," + recipe.patient.Id;
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
        public List<RecipeR> getRecipeByPatientId(String patientId)
        {
            List<RecipeR> recipes = new List<RecipeR>();
            string[] lines = System.IO.File.ReadAllLines(lokacija);
           
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (patientId == fields[6])
                {

                    RecipeR r = new RecipeR(Convert.ToInt32(fields[0]), fields[1], Convert.ToDouble(fields[2]), fields[3], Convert.ToDouble(fields[4]), fields[5],fields[6]);
                    recipes.Add(r);
                }
            }
            return recipes;
        }
        public void update(RecipeR recipe)
        {
           RecipeR stari = this.GetOne(recipe.id);
            String stariRed = stari.id + "," + stari.medicine + "," + stari.quantity + "," + stari.instruction + "," + stari.howOften + "," + stari.startTime + "," + stari.patient.Id;
            String noviRed = recipe.id + "," + recipe.medicine + "," + recipe.quantity + "," + recipe.instruction + "," + recipe.howOften + "," + recipe.startTime + "," + recipe.patient.Id;
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
        public RecipeR GetOne(int id)
        {

            RecipeR recipe = null;
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
                   recipe=new RecipeR(Convert.ToInt32(fields[0]),fields[1], Convert.ToDouble(fields[2]), fields[3], Convert.ToDouble(fields[4]),fields[5],fields[6]);
                    return recipe;
                }
            }
            return recipe;
        }
    }
}
