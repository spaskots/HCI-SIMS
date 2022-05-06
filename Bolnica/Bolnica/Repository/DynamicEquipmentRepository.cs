using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repository
{
    internal class DynamicEquipmentRepository
    {
        String lokacijaDynamicEquipment = @"..\..\..\Data\DynamicEquipment.txt";

        public DynamicEquipmentRepository()
        {
            if (!File.Exists(lokacijaDynamicEquipment))
            {
                using (StreamWriter sw = File.CreateText(lokacijaDynamicEquipment))
                {
                    sw.Write("");
                }
            }
        }
        public List<DynamicEquipment> GetAllDynamicEquipments()
        {
            List<DynamicEquipment> dynamicEquipments = new List<DynamicEquipment>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaDynamicEquipment);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    int id = Convert.ToInt32(fields[0]);
                    string name = fields[1];
                    int quantity = Convert.ToInt32(fields[2]);
                    DynamicEquipment dynamicEquipment = new DynamicEquipment(id, name, quantity);
                    dynamicEquipments.Add(dynamicEquipment);
                }
            }
            return dynamicEquipments;
        }
        public List<DynamicEquipment> search(String Name)
        {
            List<DynamicEquipment> dynamicEquipments = GetAllDynamicEquipments();
            List<DynamicEquipment> results = new List<DynamicEquipment>();
            foreach (DynamicEquipment dynamicEquipment in dynamicEquipments)
            {

                if(dynamicEquipment.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    results.Add(dynamicEquipment);
                }
            }
            return results;
        }
    }
}
