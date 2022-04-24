﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;


namespace Bolnica.Repository
{
    internal class StaticEquipmentRepository
    {
        String lokacijaStaticEquipment = @"..\..\..\Data\StaticEquipment.txt";

        public StaticEquipmentRepository()
        {
            if (!File.Exists(lokacijaStaticEquipment))
            {
                using (StreamWriter sw = File.CreateText(lokacijaStaticEquipment))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(lokacijaStaticEquipment))
            {
                using (StreamWriter sw = File.CreateText(lokacijaStaticEquipment))
                {
                    sw.Write("");
                }
            }
        }
        public List<StaticEquipment> GetAllStaticEquipment()
        {
            List<StaticEquipment> staticEquipments = new List<StaticEquipment>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaStaticEquipment);
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

                    StaticEquipment staticEquipment = new StaticEquipment(id, name, quantity);
                    staticEquipments.Add(staticEquipment);
                }
            }
            return staticEquipments;
        }
        public StaticEquipment AddStaticEquipment(StaticEquipment staticEquipment)
        {
            String noviRed = staticEquipment.Id + "," + staticEquipment.Name + "," + staticEquipment.Quantity;
            StreamWriter write = new StreamWriter(lokacijaStaticEquipment, true);
            write.WriteLine(noviRed);
            write.Close();
            return staticEquipment;
        }
        public Boolean Delete(StaticEquipment staticEquipment)
        {
            String obrisiRed = staticEquipment.Id + "," + staticEquipment.Name + "," + staticEquipment.Quantity;

            String text = File.ReadAllText(lokacijaStaticEquipment);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(lokacijaStaticEquipment, text);
                return true;
            }
            return false;

        }
        public StaticEquipment FindById(int id)
        {
            try
            {
                return GetAllStaticEquipment().SingleOrDefault(staticEquipment => staticEquipment.Id == id);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public StaticEquipment Update(StaticEquipment staticEquipment)
        {
            StaticEquipment oldStaticEquipment = FindById(staticEquipment.Id);
            Delete(oldStaticEquipment);
            AddStaticEquipment(staticEquipment);
            return staticEquipment;
        }
    }
}
