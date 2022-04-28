using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    internal class StaticEquipmentService
    {
    StaticEquipmentRepository _repository = new StaticEquipmentRepository();
        public StaticEquipmentService()
        {
        }
        public StaticEquipment AddStaticEquipment(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _repository.AddStaticEquipment(staticEquipment);
        }
        public MoveExecution MoveExecutionSubmit(MoveExecution me)
        {
            // TODO: implement
            return _repository.MoveExecutionSubmit(me);
        }
        

        public StaticEquipment Update(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _repository.Update(staticEquipment);
        }

        public Boolean Delete(StaticEquipment staticEquipment)
        {
            // TODO: implement
            return _repository.Delete(staticEquipment);
        }

        public List<StaticEquipment> getAllStaticEquipment()
        {
            return _repository.GetAllStaticEquipment();
        }
        
    }
}
