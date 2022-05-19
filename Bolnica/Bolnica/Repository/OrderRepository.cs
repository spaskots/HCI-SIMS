using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repository
{
    public class OrderRepository
    {
        String ISSUED_ORDERS_FILE = @"..\..\..\Data\IssuedOrders.txt";
        const int ORDER_ARRIVAL_TIME = 3;
        public OrderRepository()
        {
            if (!File.Exists(ISSUED_ORDERS_FILE))
            {
                using (StreamWriter writer = File.CreateText(ISSUED_ORDERS_FILE))
                {
                    writer.Write("");
                }
            }
        }
        /*public Boolean IssueOrder (DynamicEquipment equipmentToOrder, int orderAmount)
        {
            return Save(equipmentToOrder, orderAmount);
        }*/

        public Boolean Save(DynamicEquipment equipmentToOrder, int orderAmount)
        {
            try
            {
                DateTime orderDeliveryDate = DateTime.Now.AddDays(ORDER_ARRIVAL_TIME);
                using (StreamWriter writer = File.AppendText(ISSUED_ORDERS_FILE))
                {
                    writer.WriteLine(string.Format("{0},{1},{2}", equipmentToOrder.Id, orderDeliveryDate, orderAmount));
                }
                
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
                return false;
            }
        }

        public void Delete(string[] lineToDelete)
        {
            String rowToDelete = string.Format("{0},{1},{2}", lineToDelete[0], lineToDelete[1], lineToDelete[2]);
            String allDataFromFile = File.ReadAllText(ISSUED_ORDERS_FILE);

            if (allDataFromFile.Contains(rowToDelete))
            {
                allDataFromFile = allDataFromFile.Replace(rowToDelete, "");
                File.WriteAllText(ISSUED_ORDERS_FILE, allDataFromFile);
                var allLines = File.ReadAllLines(ISSUED_ORDERS_FILE).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(ISSUED_ORDERS_FILE, allLines);
            }


        }

        public string[] Read()
        {
            return System.IO.File.ReadAllLines(ISSUED_ORDERS_FILE);
        }
    }
}
