using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;

namespace Bolnica.Service
{
    public class VacationRequestService
    {
        VacationRequestRepository _requestRepository = new VacationRequestRepository();

        public void Update(VacationRequest vacationRequest)
        {
            _requestRepository.Update(vacationRequest);
        }

    }
}
