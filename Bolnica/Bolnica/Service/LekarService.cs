using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Repository;
namespace Bolnica.Service
{
    
            
    public class LekarService
    {
        LekarRepository lekarRepository = new LekarRepository();
        public void saveDoctor(Doctor doctor)
        {
            lekarRepository.saveDoctor(doctor);
        }
        public void LogIn(String username,String password)
        {
            lekarRepository.LogIn(username, password);
        }
        public List<Doctor> getAllDoctors()
        {
            return lekarRepository.getAllDoctors();
        }
    }
}
