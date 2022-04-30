using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class RenovationExecution
    {
        public string roomId { get; set; }

        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Description { get; set; }

        public RenovationExecution()
        {
        }

        public RenovationExecution(DateTime startDate, DateTime endDate, String roomId, String Description)
        {
            this.StartDate = startDate.ToString();
            this.EndDate = endDate.ToString();
            this.roomId = roomId;
            this.Description = Description;

        }
    }
}
