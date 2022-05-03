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
        public List<MedicalAppointment> GetAllAppointmentsByDoctorId(String id)
        {
           return appointmentRepository.GetAllAppointmentsByDoctorId(id);
        }
        public void delete(MedicalAppointment ma)
        {
            appointmentRepository.delete(ma);
        }
        public List<int> getAllId()
        {
            return appointmentRepository.getAllId();
        }
        public void update(MedicalAppointment ma)
        {
            appointmentRepository.update(ma);
        }
        public List<MedicalAppointment> GetAllAppointments()
        {
            return appointmentRepository.GetAllAppointments();
        }
        
    }
}
