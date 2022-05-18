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

        public DynamicEquipment GetById(int equipmentId)
        {
            string[] allDynamicEquipment = File.ReadAllLines(lokacijaDynamicEquipment);

            foreach (string dynamicEquipment in allDynamicEquipment)
            {
                string[] fieldsOfData = dynamicEquipment.Split(",");
                if (dynamicEquipment == "") { continue; }
                if (Convert.ToInt32(fieldsOfData[0]) == equipmentId)
                {
                    return new DynamicEquipment(Convert.ToInt32(fieldsOfData[0]), fieldsOfData[1], Convert.ToInt32(fieldsOfData[2]));
                }
            }
           return null;
        }

        public void Update(DynamicEquipment updatedEquipment)
        {
            DynamicEquipment oldDynamicEquipment = GetById(updatedEquipment.Id);

            String oldEquipmentLine = string.Format("{0},{1},{2}", oldDynamicEquipment.Id, oldDynamicEquipment.Name, oldDynamicEquipment.Quantity);
            String updatedEquipmentLine = string.Format("{0},{1},{2}", updatedEquipment.Id, updatedEquipment.Name, updatedEquipment.Quantity);
            String allEquipmentLines = File.ReadAllText(lokacijaDynamicEquipment);

            if (allEquipmentLines.Contains(oldEquipmentLine))
            {
                allEquipmentLines = allEquipmentLines.Replace(oldEquipmentLine, updatedEquipmentLine);
                File.WriteAllText(lokacijaDynamicEquipment, allEquipmentLines);
            }
        }

        public void IncreaseEquipmentAmount(int equipmentId, int amount)
        {
            DynamicEquipment updatedEquipment = GetById(equipmentId);
            updatedEquipment.Quantity += amount;

            Update(updatedEquipment);
        }
    }
}
