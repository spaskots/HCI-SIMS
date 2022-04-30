using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class DynamicEquipment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        public DynamicEquipment() { }
         public DynamicEquipment(int Id, String Name, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = Quantity;
        }

    }
}
