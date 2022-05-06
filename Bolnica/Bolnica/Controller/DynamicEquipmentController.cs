using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    internal class DynamicEquipmentController
    {
        DynamicEquipmentService _service = new DynamicEquipmentService();
        public DynamicEquipmentController()
        {
        }
        public List<DynamicEquipment> GetAllDynamicEquipments()
        {
            return _service.GetAllDynamicEquipments();
        }
        public List<DynamicEquipment> search(String Name)
        {
            return _service.search(Name);
        }
    }
}
