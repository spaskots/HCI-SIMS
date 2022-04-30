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
        RoomRepository _repository = new RoomRepository();

        public RoomService()
        {
        }

        public Room Create(Room room)
        {
            // TODO: implement
            return _repository.Create(room);
        }

        public Room Update(Room room)
        {
            // TODO: implement
            return _repository.Update(room);
        }

        public Boolean Delete(Room room)
        {
            // TODO: implement
            return _repository.Delete(room);
        }

        public List<Room> getAllRooms()
        {
            return _repository.GetAllRooms();
        }
        public List<String> getAllId()
        {
            return _repository.getAllId();
        }
        public RenovationExecution renovation(RenovationExecution re)
        {
            return _repository.renovation(re);
        }
    }
}
