using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Service;
namespace Bolnica.Controller
{
    public class LekarController
    {
        LekarService lekarService = new LekarService();
        public void saveDoctor(Doctor doctor)
        {
            lekarService.saveDoctor(doctor);
        }
        public void LogIn(String username,String password)
        {
            lekarService.LogIn(username, password);
        }
        public List<String> getAllId()
        {
            return lekarService.getAllId();
        }
        public Doctor GetOneByUsername(String username)
        {
            return lekarService.GetOneByUsername(username);
        }
    }
}
