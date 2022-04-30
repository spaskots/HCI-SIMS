using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    internal class MoveExecution
    {
        public int staticEquipmentId;
        public String Date;
        public String ToRoomId;
        public int Quantity;
        public String Description;

        public MoveExecution(int staticEquipment, DateTime date, String ToRoomId, int Quantity, String Description)
        {
            this.staticEquipmentId = staticEquipment;
            this.Date = date.ToShortDateString();
            this.ToRoomId = ToRoomId;
            this.Quantity = Quantity;
            this.Description = Description;
        }
    }
}
