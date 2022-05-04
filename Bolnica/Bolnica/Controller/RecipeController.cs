using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Service;
namespace Bolnica.Controller
{
    public class RecipeController
    {
        RecipeService recipeService=new RecipeService();
        public void save(RecipeR recipe)
        {
            recipeService.save(recipe);
        }
        public List<RecipeR> getRecipeByPatientId(String patientId)
        {
            return recipeService.getRecipeByPatientId(patientId);
        }
        public void update(RecipeR recipe)
        {
            recipeService.update(recipe);
        }
        public List<int> getAllId()
        {
            return recipeService.getAllId();
        }
    }
   
}
