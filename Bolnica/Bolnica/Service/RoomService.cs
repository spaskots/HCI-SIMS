using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica.Service
{
    public class RoomService
    {
        RoomRepository roomRepository = new RoomRepository();
       
        public List<Room> getAllRooms()
        {
            return roomRepository.GetAllRooms();
        }
        public List<String> getAllId()
        {
            return roomRepository.getAllId();
        }
    }
}
