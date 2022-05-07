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
            if(room.Id == "1") { return false; }
            String obrisiRed = room.Id + "," + room.Name + "," + room.Floor + "," + room.Description + "," + room.RoomType;

            String text = File.ReadAllText(lokacijaDirector);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(lokacijaDirector, text); //Treba se doraditi zbog opreme koja se nalazi u ovoj sobi radi kasnijeg ispisa.
                return true;
            }
            return false;

        }

        public Room Update(Room room)
        {
            Room oldRoom = FindById(room.Id);
            String oldRow = oldRoom.Id + "," + oldRoom.Name + "," + oldRoom.Floor + "," + oldRoom.Description + "," + oldRoom.RoomType;
            String newRow = room.Id + "," + room.Name + "," + room.Floor + "," + room.Description + "," + room.RoomType;

            String text = File.ReadAllText(lokacijaDirector);
            if (text.Contains(oldRow))
            {
                text = text.Replace(oldRow, newRow);
                File.WriteAllText(lokacijaDirector, text); 
            }
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
        public AdvancedRenovationExecution advancedRenovationSave(AdvancedRenovationExecution re)
        {
            String noviRed1 = re.roomId + "," + re.StartDate + "," + re.EndDate  + "," + re.Description + "," + re.advanced;
            StreamWriter write = new StreamWriter(lokacijaRoomShedule, true);
            write.WriteLine(noviRed1);
            if (re.advanced == 'M')
            {
                String noviRed2 = re.withRoomId + "," + re.StartDate + "," + re.EndDate + "," + re.Description + "," + re.advanced;
                write.WriteLine(noviRed2); // Kada se radi merge treba 2x upisa, kada se ne radi merge treba samo jedan upis sa oznakom S.
            }
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
        StaticEquipmentRepository staticEquipment_repository = new StaticEquipmentRepository();
        public String GenerateNewRoomId()
        {
            List<Room> rooms = GetAllRooms();
            int temp = 0;
            int maxId = 1;
            foreach (Room room in rooms)
            {
                if (room == null) { return "2"; } //Zbog magacina koji uvek postoji ne bi trebalo da se ovo ikada desi ali ae
                temp = Int32.Parse(room.Id);
                if (temp > maxId) { maxId = temp; }
            }
            maxId += 1;
            return maxId.ToString();
        }
        public void advancedRenovationMergeSplit()
        {
            //Promenjive koje koristim iz prvog ali i u drugom delu.
            bool foundFirst = false;
            DateTime startDate1 = DateTime.Now;
            DateTime endDate1;
            String roomId1 = "-"; // ?

            string[] lines = System.IO.File.ReadAllLines(lokacijaRoomShedule);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                else
                {
                    if (foundFirst == false)
                    {
                        string[] fields = line.Split(',');
                        roomId1 = fields[0];
                        startDate1 = DateTime.Parse(fields[1]);
                        endDate1 = DateTime.Parse(fields[2]);
                        String description1 = fields[3];
                        String advanced1 = "";
                        try
                        {
                        advanced1 = fields[4];
                        }
                        catch (Exception easd) { }

                        if (DateTime.Compare(DateTime.Now, endDate1) >= 0 && advanced1 == "S") // zelim da generisem novu sobu
                        {
                            Room splitRoom = FindById(roomId1);
                            Room newRoom = new Room(GenerateNewRoomId(), splitRoom.Name, splitRoom.Floor, "New Room From Split!", splitRoom.RoomType);
                            Create(newRoom);
                            String text = File.ReadAllText(lokacijaRoomShedule); //Brisanje linije i nastavljanje dalje.
                            text = text.Replace(line, "");
                            File.WriteAllText(lokacijaRoomShedule, text);
                        }

                            if (DateTime.Compare(DateTime.Now, endDate1) >= 0 && advanced1 == "M") // Mora datum da prodje i da ima specijalni karatker za Advanced Logiku.
                        {
                            //Za pocetak mu treba naci parnjaka 
                            foundFirst = true;
                            //Kako smo sigurni da parnjak u ovim uslovima mora da postoji, ovu liniju mozemo komotno da obrisemo
                            String text = File.ReadAllText(lokacijaRoomShedule); //Brisanje te linije.
                            text = text.Replace(line, "");
                            File.WriteAllText(lokacijaRoomShedule, text);
                        }
                    }
                    else
                    {
                        string[] fields = line.Split(',');
                        String roomId2 = fields[0];
                        DateTime startDate2 = DateTime.Parse(fields[1]);
                        DateTime endDate2 = DateTime.Parse(fields[2]);
                        String description2 = fields[3];
                        String advanced2 = "";
                        try
                        {
                        advanced2 = fields[4];
                        }
                        catch (Exception easd) {  }

                        if (DateTime.Compare(startDate1, startDate2) == 0 && advanced2 == "M") // Nalazimo mu parnjaka
                        {
                            //Spajanje druge navedene u prvu -> prebacivanje sve opreme iz druge u prvu sobu
                            List<StaticEquipment> staticEquipmentsRoom2 = staticEquipment_repository.getEquipmentInChosenRoom(roomId2);
                            foreach(StaticEquipment staticRoom2 in staticEquipmentsRoom2)
                            {
                                staticRoom2.roomId = roomId1;
                                staticEquipment_repository.Update(staticRoom2);
                            }
                            //Sada mozemo obrisati sobu 2 Komotno i usput promeniti opis prvoj sobi cisto da znamo da se desila izmena
                            Delete(FindById(roomId2)); //Brisi ovu sobu
                            Room firstRoomUpdate = FindById(roomId1);
                            firstRoomUpdate.Description = "Merged room with id " + roomId1 + " with room " + roomId2;
                            Update(firstRoomUpdate);
                            //Sada mogu da obrisem ovu liniju

                            String text = File.ReadAllText(lokacijaRoomShedule); //Brisanje te linije.
                            text = text.Replace(line, "");
                            File.WriteAllText(lokacijaRoomShedule, text);

                            advancedRenovationMergeSplit(); // Kada sam obrisao i uradio nesto opet pozivam funckiju u slucaju da ima vise toga da se odradi.
                        }

                    }
                };
            }
        }
    }
}
