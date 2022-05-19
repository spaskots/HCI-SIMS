using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    public class OrderService
    {
        OrderRepository _orderRepository = new OrderRepository();
        DynamicEquipmentRepository _dynamicEquipmentRepository = new DynamicEquipmentRepository();
        public Boolean IssueOrder (DynamicEquipment equipmentToOrder, int orderAmount)
        {
            return _orderRepository.Save(equipmentToOrder, orderAmount);
        }

        public void CheckOrders()
        {
            string[] ollOrders = _orderRepository.Read();
            DateTime currentTime = DateTime.Now;

            foreach (string order in ollOrders)
            {
                if (order == "") continue;
                string[] fieldsOfData = order.Split(",");
                if (!IsOrderDelivered(Convert.ToDateTime(fieldsOfData[1]), currentTime)) continue;
                _dynamicEquipmentRepository.IncreaseEquipmentAmount(Convert.ToInt32(fieldsOfData[0]), Convert.ToInt32(fieldsOfData[2]));
                _orderRepository.Delete(fieldsOfData);
            }
        }
  
        public Boolean IsOrderDelivered(DateTime orderDeliveryDate, DateTime currentTime)
        {
            return DateTime.Compare(orderDeliveryDate, currentTime) < 0;
        }
    }
}
