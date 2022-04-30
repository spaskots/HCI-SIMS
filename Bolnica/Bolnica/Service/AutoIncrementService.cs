using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica.Service
{
   public  class AutoIncrementService
    {
        AutoIncrementRepository autoIncrementRepository=new AutoIncrementRepository();
        public List<int> getAll()
        {
            return autoIncrementRepository.getAll();
        }
        public void saveOne(AutoIncrement ai)
        {
            autoIncrementRepository.saveOne(ai);
        }
    }
}
