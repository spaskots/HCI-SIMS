using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    internal class IngredientController
    {
        IngredientService _service = new IngredientService();
        public IngredientController()
        {
        }
        public Ingredient AddIngredient(Ingredient ingredient)
        {
            return _service.AddIngredient(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            // TODO: implement
            return _service.Update(ingredient);
        }

        public Boolean Delete(Ingredient ingredient)
        {
            return _service.Delete(ingredient);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _service.GetAllIngredients();
        }
    }
}
