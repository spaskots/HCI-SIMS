using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class VacationRequest
    {
        public String DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String ?Note { get; set; }
        public VacationRequestState State { get; set; }

        public VacationRequest(String DoctorId, DateTime StartDate, DateTime EndDate)
        {
            this.DoctorId = DoctorId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.State = VacationRequestState.Unreviewed;
        }

        public VacationRequest(String DoctorId, DateTime StartDate, DateTime EndDate, VacationRequestState State)
        {
            this.DoctorId = DoctorId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.State = State;
        }

        public VacationRequest(String DoctorId, DateTime StartDate, DateTime EndDate, String Note, VacationRequestState State)
        {
            this.DoctorId = DoctorId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Note = Note;
            this.State = State;
        }

    }
}
