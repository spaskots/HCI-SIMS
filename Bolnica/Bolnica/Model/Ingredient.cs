using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Ingredient() { }
        public Ingredient(int Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
