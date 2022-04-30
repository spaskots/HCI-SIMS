using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class RoomRepository
    {
        String lokacijaSoba = @"..\..\..\Data\Soba.txt";
        String lokacijaDirector = @"..\..\..\Data\SobaDirector.txt";
        String lokacijaRoomShedule = @"..\..\..\Data\RoomShedule.txt";

        public RoomRepository()
        {
            if (!File.Exists(lokacijaDirector))
            {
                using (StreamWriter sw = File.CreateText(lokacijaDirector))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(lokacijaSoba))
            {
                using (StreamWriter sw = File.CreateText(lokacijaSoba))
                {
                    sw.Write("");
                }
            }
            if (!File.Exists(lokacijaRoomShedule))
            {
                using (StreamWriter sw = File.CreateText(lokacijaSoba))
                {
                    sw.Write("");
                }
            }
        }
      
        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaDirector);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');

                    String id = fields[0];
                    string name = fields[1];
                    RoomType type;

                    String floor = fields[2];
                    String description = fields[3];
                    Enum.TryParse(fields[4], out type);

                    Room room = new Room(id, name, floor, description, type);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public Room Create(Room room)
        {
            String noviRed = room.Id + "," + room.Name + "," + room.Floor + "," + room.Description + "," + room.RoomType;
            StreamWriter write = new StreamWriter(lokacijaDirector, true);
            write.WriteLine(noviRed);
            write.Close();
            return room;
        }

        public Boolean Delete(Room room)
        {
            String obrisiRed = room.Id + "," + room.Name + "," + room.Floor + "," + room.Description + "," + room.RoomType;

            String text = File.ReadAllText(lokacijaDirector);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(lokacijaDirector, text);
                return true;
            }
            return false;

        }

        public Room Update(Room room)
        {
            Room oldRoom = FindById(room.Id);
            Delete(oldRoom);
            Create(room);
            return room;
        }
        public Room FindById(String id)
        {
            try
            {
                return GetAllRooms().SingleOrDefault(room => room.Id == id);
            }
            catch (ArgumentException)
            {
                //throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));
                return null;
            }
        }

        public List<String> getAllId()
        {
            List<String> ids = new List<String>();
            string[] lines = System.IO.File.ReadAllLines(lokacijaSoba);
            foreach (String line in lines)
            {
                string[] fields = line.Split(',');
                string id = fields[0];
                ids.Add(id);
            }
            return ids;
        }

        public RenovationExecution renovation(RenovationExecution re)
            {
                String noviRed = re.roomId + "," + re.StartDate + "," + re.EndDate + "," + re.Description;
                StreamWriter write = new StreamWriter(lokacijaRoomShedule, true);
                write.WriteLine(noviRed);
                write.Close();
                return re;
            }
        public List<DateTime> takenRoomDates(String roomId)
        {

            List<DateTime> dates = new List<DateTime>();
            string[] lines = System.IO.File.ReadAllLines(lokacijaRoomShedule);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    string[] fields = line.Split(',');
                    String roomTekuciId = fields[0];
                    if(roomTekuciId == roomId) { 
                        DateTime startDate = DateTime.Parse(fields[1]);
                        DateTime endDate = DateTime.Parse(fields[2]);
                        dates.Add(startDate);
                        dates.Add(endDate); // Dodavanje samo datuma jer me vreme ne zanima ako ima nesto znaci da je planirano taj dan da radi bolnica
                    }
                }
            }
            return dates;
        }
    }
}
