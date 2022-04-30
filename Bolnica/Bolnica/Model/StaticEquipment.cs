using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    internal class StaticEquipment
    {
        

        public String roomId { get; set; }
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public StaticEquipment()
        {
        }

        public StaticEquipment(int Id, String Name, int quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = quantity;
            this.roomId = "1";
        }
        public StaticEquipment(int Id, String Name, int quantity, string roomId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Quantity = quantity;
            this.roomId = roomId;
        }

    }
    
}
