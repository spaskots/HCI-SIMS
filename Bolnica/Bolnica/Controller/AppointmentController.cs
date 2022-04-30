using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
using Bolnica.Model;
namespace Bolnica.Controller
{
    public class AppointmentController
    {
        AppointmentService appointmentService=new AppointmentService();
        public void save(MedicalAppointment ma)
        {
            appointmentService.save(ma);
        }
        public List<MedicalAppointment> getAllAppointment(String id)
        {
            return appointmentService.getAllAppointment(id);
        }
        public void delete(MedicalAppointment ma)
        {
            appointmentService.delete(ma);
        }
        public void update(MedicalAppointment ma)
        {
            appointmentService.update(ma);
        }
        public List<int> getAllId()
        {
            return appointmentService.getAllId();
        }
    }
}
