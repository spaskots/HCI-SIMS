using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica.Service
{
    public class RecipeService
    {
        RecipeRepository recipeRepository= new RecipeRepository();  
        public void save(RecipeR recipe)
        {
            recipeRepository.save(recipe);
        }
        public List<RecipeR> getRecipeByPatientId(String patientId)
        {
            return recipeRepository.getRecipeByPatientId(patientId);
        }
        public void update(RecipeR recipe)
        {
            recipeRepository.update(recipe);
        }
        public List<int> getAllId()
        {
            return recipeRepository.getAllId();
        }
    }
}
