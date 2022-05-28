using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;

namespace Bolnica.Controller
{
    public class VacationRequestController
    {
        VacationRequestService requestService = new VacationRequestService();

        public void Update(VacationRequest vacationRequest)
        {
            requestService.Update(vacationRequest);
        }
    }
}
