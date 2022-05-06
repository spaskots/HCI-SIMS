using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    internal class StaticEquipmentController
    {
        StaticEquipmentService _service = new StaticEquipmentService();

        public StaticEquipment Create(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _service.AddStaticEquipment(staticEquipment);
        }
        public MoveExecution MoveExecutionSubmit(MoveExecution me)
        {
            // TODO: implement
            return _service.MoveExecutionSubmit(me);
        }
        public StaticEquipment Update(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _service.Update(staticEquipment);
        }

        public Boolean Delete(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _service.Delete(staticEquipment);
        }

        public List<StaticEquipment> getAllStaticEquipment()
        {
            // TODO: implement
            return _service.getAllStaticEquipment();
        }
        public List<StaticEquipment> search(String name, String idRoom = "-")
        {
            return _service.search(name, idRoom);
        }
    }
}
