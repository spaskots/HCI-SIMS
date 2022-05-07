using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    internal class CureController
    {
        CureService _service = new CureService();
        public CureController()
        {
        }
        public Cure AddCure(Cure cure)
        {
            return _service.AddCure(cure);
        }

        public Cure Update(Cure cure)
        {
            // TODO: implement
            return _service.Update(cure);
        }

        public Boolean Delete(Cure cure)
        {
            return _service.Delete(cure);
        }

        public List<Cure> GetAllCures()
        {
            return _service.GetAllCures();
        }
    }
}
