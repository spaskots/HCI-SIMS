using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    internal class DynamicEquipmentService
    {
        DynamicEquipmentRepository _repository = new DynamicEquipmentRepository();
        public DynamicEquipmentService()
        {
        }
        public List<DynamicEquipment> GetAllDynamicEquipments()
        {
            return _repository.GetAllDynamicEquipments();
        }
    }
}
