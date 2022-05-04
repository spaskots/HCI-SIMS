using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{


    public class Room
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Floor { get; set; }
        public String Description { get; set; }
        public RoomType RoomType { get; set; }


        public Room()

        {

        }

        public Room(String Id, String Name, String Floor, String Description, RoomType RoomType)
        {
            this.Id = Id;
            this.Name = Name;
            this.Floor = Floor;
            this.Description = Description;
            this.RoomType = RoomType;

        }

    }
}