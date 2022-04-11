using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
namespace Bolnica.Controller
{
   public class RoomController
    {
        RoomService roomService=new RoomService();
        public List<String> getAllId()
        {
            return roomService.getAllId();
        }
    }
    
}
