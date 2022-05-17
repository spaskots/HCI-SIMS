using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    public class OrderController
    {
        OrderService _orderService = new OrderService();
        public Boolean IssueOrder(DynamicEquipment equipmentToOrder, int orderAmount)
        {
            return _orderService.IssueOrder(equipmentToOrder, orderAmount);
        }

        public void CheckOrders()
        {
            _orderService.CheckOrders();
        }
    }
}
