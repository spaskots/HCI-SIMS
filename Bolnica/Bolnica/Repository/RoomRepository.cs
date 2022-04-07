using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class RoomRepository
    {
        String lokacijaSoba = @"C:\Users\Korisnik\Desktop\SIMS Projekat\HCI-SIMS\Bolnica\Soba.txt";
        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaSoba);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                string id = fields[0];
                string name = fields[1];
                string floor = fields[2];
                string description = fields[3];
                bool isAvailable = Convert.ToBoolean(fields[4]);
                RoomType type;

                Enum.TryParse(fields[5], out type);
                
                Room room = new Room(id, name, floor, description,isAvailable, type);
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
