using Bolnica.Model;
using Bolnica.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    public class RoomController
    {
        RoomService _service = new RoomService();

        //public RoomContoller(RoomService service)
        //{
        //    _service = service;
        //}

        public Room Create(Room room)
        {
            // TODO: implement
            return _service.Create(room);
        }

        public Room Update(Room room)
        {
            // TODO: implement
            return _service.Update(room);
        }

        public Boolean Delete(Room room)
        {
            // TODO: implement
            return _service.Delete(room);
        }

        public List<Room> getAllRooms()
        {
            // TODO: implement
            return _service.getAllRooms();
        }

        public List<String> getAllId()
        {
            return _service.getAllId();
        }
        public RenovationExecution renovation(RenovationExecution re)
        {
            return _service.renovation(re);
        }
    }
}
