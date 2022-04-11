using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
using Bolnica.Repository;
namespace Bolnica.Service
{
    public class AppointmentService
    {
        AppointmentRepository appointmentRepository= new AppointmentRepository();
        public void save(MedicalAppointment ma)
        {
            appointmentRepository.save(ma);
        }
        public List<MedicalAppointment> getAllAppointment(String id)
        {
           return appointmentRepository.getAllAppointment(id);
        }
        public void delete(MedicalAppointment ma)
        {
            appointmentRepository.delete(ma);
        }
        public void update(MedicalAppointment ma)
        {
            appointmentRepository.update(ma);
        }
        
    }
}
