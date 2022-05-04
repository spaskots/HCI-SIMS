using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using Bolnica.Model;
namespace Bolnica.Controller
{
   
    public class AutoIncrementController
    {
        AutoIncrementService autoIncrementService = new AutoIncrementService();

        public List<int > getAll()
        {
            return autoIncrementService.getAll();
        }
        public void saveOne(AutoIncrement ai)
        {
            autoIncrementService.saveOne(ai);
        }
    }
}
