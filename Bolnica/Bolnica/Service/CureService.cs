using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    internal class CureService
    {
        CureRepository _repository = new CureRepository();
        public CureService()
        {
        }
        public Cure AddCure(Cure cure)
        {
            return _repository.AddCure(cure);
        }

        public Cure Update(Cure cure)
        {
            // TODO: implement
            return _repository.Update(cure);
        }

        public Boolean Delete(Cure cure)
        {
            return _repository.Delete(cure);
        }

        public List<Cure> GetAllCures()
        {
            return _repository.GetAllCures();
        }
    }
}
