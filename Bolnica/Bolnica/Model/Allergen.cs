using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Allergen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Allergen() { }

        public Allergen(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Allergen(string name)
        {
            Name = name;
        }
    }
}
