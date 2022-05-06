using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class AdvancedRenovationExecution
    {
        public string roomId { get; set; }
        public string withRoomId { get; set; }
        public char advanced { get; set; }

        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Description { get; set; }

        public AdvancedRenovationExecution()
        {
        }

        public AdvancedRenovationExecution(DateTime startDate, DateTime endDate, String roomId, String withRoomId, String Description)
        {
            this.StartDate = startDate.ToString();
            this.EndDate = endDate.ToString();
            this.roomId = roomId;
            this.Description = Description;
            this.withRoomId = withRoomId;
            this.advanced = 'M';

        }
        public AdvancedRenovationExecution(DateTime startDate, DateTime endDate, String roomId,  String Description)
        {
            this.StartDate = startDate.ToString();
            this.EndDate = endDate.ToString();
            this.roomId = roomId;
            this.Description = Description;
            this.advanced = 'S';

        }
    }
}
