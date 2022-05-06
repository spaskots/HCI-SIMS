using System;
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
        String lokacijaMoveExecution = @"..\..\..\Data\MoveExecution.txt";

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
            if (!File.Exists(lokacijaMoveExecution))
            {
                using (StreamWriter sw = File.CreateText(lokacijaMoveExecution))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(lokacijaMoveExecution))
            {
                using (StreamWriter sw = File.CreateText(lokacijaMoveExecution))
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
                    String roomId = fields[3];
                    StaticEquipment staticEquipment = new StaticEquipment(id, name, quantity, roomId);
                    staticEquipments.Add(staticEquipment);
                }
            }
            return staticEquipments;
        }
        public MoveExecution MoveExecutionSubmit(MoveExecution moveExecution)
        {
            String noviRed = moveExecution.staticEquipmentId + "," + moveExecution.Date + "," + moveExecution.ToRoomId + "," + moveExecution.Quantity + "," + moveExecution.Description;
            StreamWriter write = new StreamWriter(lokacijaMoveExecution, true);
            write.WriteLine(noviRed);
            write.Close();
            return moveExecution;
        }
        public StaticEquipment AddStaticEquipment(StaticEquipment staticEquipment)
        {
            String noviRed = staticEquipment.Id + "," + staticEquipment.Name + "," + staticEquipment.Quantity + "," + staticEquipment.roomId;
            StreamWriter write = new StreamWriter(lokacijaStaticEquipment, true);
            write.WriteLine(noviRed);
            write.Close();
            return staticEquipment;
        }
        public Boolean Delete(StaticEquipment staticEquipment)
        {
            String obrisiRed = staticEquipment.Id + "," + staticEquipment.Name + "," + staticEquipment.Quantity + "," + staticEquipment.roomId;

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
        public StaticEquipment FindByEqIdAndRoomId(int id, String roomId)
        {
            try
            {
                return GetAllStaticEquipment().SingleOrDefault(staticEquipment => staticEquipment.Id == id & staticEquipment.roomId == roomId);
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

        public int GenerateNewEqId() {
            List<StaticEquipment> ses = GetAllStaticEquipment();
            int temp = 0;
            int maxId = 1;
            foreach (StaticEquipment se in ses)
            { 
                if(se == null) { return 1; }
                temp = se.Id;
                if (temp > maxId) { maxId = temp; }
            }
            maxId += 1;
            return maxId;
        }
        public Boolean MoveExecutionDo()
        {
            DateTime now = DateTime.Now;
            string[] lines = System.IO.File.ReadAllLines(lokacijaMoveExecution);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    int StaticEquipmentId = Convert.ToInt32(fields[0]);
                    DateTime dateOfMove = DateTime.Parse(fields[1]);
                    String toRoom = fields[2];
                    int quantity = Convert.ToInt32(fields[3]);
                    String Description = fields[4];
                    if (DateTime.Compare(DateTime.Now, dateOfMove) > 0) { //Ovo znaci da move treba da se obavi ili se vec trebalo obaviti
                        StaticEquipment zaUpdateEquipmenet = FindById(StaticEquipmentId);

                        // Update kolicine u trenutnoj sobi
                        if (zaUpdateEquipmenet.Quantity - quantity == 0) { zaUpdateEquipmenet.roomId = toRoom; Update(zaUpdateEquipmenet); } // Samo promeni u kojoj je sobi oprema jer svakako svu prebacujemo.
                        else
                        {
                            zaUpdateEquipmenet.Quantity -= quantity;
                            Update(zaUpdateEquipmenet);
                            //Trazenje nove sobe i gledanje da li tamo postoji vec ova oprema, ako ne napravi je i stavi ovu sobu u suprotnom samo dodaj na kolicinu.
                            StaticEquipment destinacijaEquip = FindByEqIdAndRoomId(StaticEquipmentId, toRoom);
                            if (destinacijaEquip == null)
                            {
                                zaUpdateEquipmenet.Id = GenerateNewEqId();
                                zaUpdateEquipmenet.roomId = toRoom;
                                zaUpdateEquipmenet.Quantity = quantity;
                                AddStaticEquipment(zaUpdateEquipmenet);
                            }
                            else { destinacijaEquip.Quantity += quantity; Update(destinacijaEquip); }

                            String text = File.ReadAllText(lokacijaMoveExecution); //Brisanje te linije.
                            text = text.Replace(line, "");
                            File.WriteAllText(lokacijaMoveExecution, text);
                        }

                    }
                };
            }

            return true; //Nije zavrsena metoda.
        }
        public List<StaticEquipment> getEquipmentInChosenRoom(String roomId)
        {
            List<StaticEquipment> staticEquipments = GetAllStaticEquipment();
            List<StaticEquipment> allEqInChosenRoom = new List<StaticEquipment>();
            foreach(StaticEquipment eq in staticEquipments)
            {
                if (Int32.Parse(eq.roomId) == Int32.Parse(roomId))
                {
                    allEqInChosenRoom.Add(eq);
                }
            }
            return allEqInChosenRoom;
        }
        public List<StaticEquipment> search(String Name, String idRoom)
        {
            List<StaticEquipment> staticEquipments = new List<StaticEquipment>();
            if(idRoom == "-") { staticEquipments.AddRange(GetAllStaticEquipment()); }
            else { staticEquipments.AddRange(getEquipmentInChosenRoom(idRoom)); }

            List<StaticEquipment> results = new List<StaticEquipment>();
            foreach (StaticEquipment staticEquipment in staticEquipments)
            {

                if (staticEquipment.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    results.Add(staticEquipment);
                }
            }
            return results;
        }
    }
}
