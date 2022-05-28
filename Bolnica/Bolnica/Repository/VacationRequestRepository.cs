using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using System.IO;
using System.Linq;

namespace Bolnica.Repository
{
    public class VacationRequestRepository
    {

        String REQUEST_FILE = @"..\..\..\Data\Request.txt";

        public VacationRequestRepository()
        {
            if (!File.Exists(REQUEST_FILE))
            {
                using (StreamWriter sw = File.CreateText(REQUEST_FILE))
                {
                    sw.Write("");
                }
            }
        }

        public VacationRequest FindByDoctorId(String doctorId)
        {
            VacationRequest request = null;
            string[] lines = System.IO.File.ReadAllLines(REQUEST_FILE);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (doctorId == fields[0])
                {
                    VacationRequestState state;
                    Enum.TryParse(fields[3], out state);
                    request = new VacationRequest(fields[0], Convert.ToDateTime(fields[1]).Date, Convert.ToDateTime(fields[2]).Date, state);
                    break;
                }
            }
            return request;
        }

        public void Update(VacationRequest updatedRequest)
        {
            VacationRequest request = this.FindByDoctorId(updatedRequest.DoctorId);
            String currentRow = request.DoctorId + "," + request.StartDate + "," + request.EndDate + "," + request.State;
            String updatedRow = updatedRequest.DoctorId + "," + updatedRequest.StartDate + "," + updatedRequest.EndDate + "," + updatedRequest.State;

            String data = File.ReadAllText(REQUEST_FILE);

            if (data.Contains(currentRow)) 
            {
                data = data.Replace(currentRow, updatedRow);
                File.WriteAllText(REQUEST_FILE, data);
            }
        }
    }
}
