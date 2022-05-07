using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    internal class IngredientService
    {
        IngredientRepository _repository = new IngredientRepository();
        public IngredientService()
        {
        }
        public Ingredient AddIngredient(Ingredient ingredient)
        {
            return _repository.AddIngredient(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            // TODO: implement
            return _repository.Update(ingredient);
        }

        public Boolean Delete(Ingredient ingredient)
        {
            return _repository.Delete(ingredient);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _repository.GetAllIngredients();
        }
    }
}
