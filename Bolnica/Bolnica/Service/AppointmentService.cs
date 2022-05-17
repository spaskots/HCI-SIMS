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
        LekarRepository doctorRepository = new LekarRepository();
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

        public List<MedicalAppointment> FindByPriority(String priority, String doctorId, DateTime startTime, DateTime endTime, int duration, String appointmentType)
        {
            
            if (DateTime.Compare(startTime, endTime) == 0)
            {
                endTime = endTime.AddDays(1);
                System.Diagnostics.Debug.WriteLine(startTime + ":::" + endTime);
            }
            List<MedicalAppointment> availableSlots = GeneratePossibleSlots(startTime, endTime);
            List<MedicalAppointment> filteredAppointments = new List<MedicalAppointment>();

            List<MedicalAppointment> appointments = appointmentRepository.GetAllAppointmentsByDoctorId(doctorId);
            availableAppointments(filteredAppointments, availableSlots, appointments, doctorId, duration, appointmentType);

            System.Diagnostics.Debug.WriteLine("Preloop");
            foreach(MedicalAppointment appointment in filteredAppointments)
            {

                System.Diagnostics.Debug.WriteLine(appointment.StartTime);
            }

            if (filteredAppointments.Count > 0)
            {
                return filteredAppointments;
            }

            System.Diagnostics.Debug.WriteLine(priority);
            filteredAppointments.Clear();
            if (priority == "date")
            {
                
                //List<MedicalAppointment> allAppointments = appointmentRepository.GetAllAppointments();
                List<Doctor> doctors = doctorRepository.getAllDoctors();
                foreach (Doctor doctor in doctors)
                {
                    List<MedicalAppointment> app = appointmentRepository.GetAllAppointmentsByDoctorId(doctor.Id);
                    availableAppointments(filteredAppointments,availableSlots, app, doctor.Id, duration, appointmentType);
                }

            } else if (priority == "doctor")
            {
                int searchAttempt = 0;
                while (filteredAppointments.Count == 0 && searchAttempt < 2)
                {
                    DateTime newStart = startTime.AddDays(searchAttempt+1);
                    DateTime newEnd = endTime.AddDays(searchAttempt + 1);
                    availableSlots = GeneratePossibleSlots(newStart, newEnd);
                    appointments = appointmentRepository.GetAllAppointmentsByDoctorId(doctorId);
                    availableAppointments(filteredAppointments, availableSlots, appointments, doctorId, duration, appointmentType);
                    searchAttempt++;
                }
            }
 
            return filteredAppointments;
        }

        List<MedicalAppointment> GeneratePossibleSlots(DateTime startTime, DateTime endTime)
        {
            List<MedicalAppointment> possibleSlots = new List<MedicalAppointment>();
            var interval = endTime - startTime;
            for (int i = 0; i < interval.Days; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    DateTime begin;
                    DateTime end;
                    if (startTime.Day + i > DateTime.DaysInMonth(startTime.Year, startTime.Month))
                    {
                        int day = startTime.Day + i - DateTime.DaysInMonth(startTime.Year, startTime.Month);
                        if (startTime.Month == 12)
                        {
                            begin = new DateTime(startTime.Year + 1, 1, day, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                            end = new DateTime(startTime.Year + 1, 1, day, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                        }
                        else
                        {
                            begin = new DateTime(startTime.Year, startTime.Month + 1, day, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                            end = new DateTime(startTime.Year, startTime.Month + 1, day, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                        }
                    }
                    else
                    {
                        begin = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j, startTime.Minute, startTime.Second);
                        end = new DateTime(startTime.Year, startTime.Month, startTime.Day + i, startTime.Hour + 8 + j + 1, startTime.Minute, startTime.Second);
                    }
                    MedicalAppointment a = new MedicalAppointment(begin.ToString(), 1);
                    possibleSlots.Add(a);
                }
            }
            return possibleSlots;
        }

        void availableAppointments(List<MedicalAppointment> filteredAppointments, List<MedicalAppointment> slots, List<MedicalAppointment> appointments, String doctorId, int duration, String appointmentType)
        {
            //List<MedicalAppointment> availableAppointments = new List<MedicalAppointment>();

            bool filter;

            foreach(MedicalAppointment slot in slots)
            {
                filter = false;

                foreach(MedicalAppointment appointment in appointments)
                {
                    DateTime appointedDate = DateTime.ParseExact(appointment.StartTime, "dd/MM/yyyy HH:mm:ss", null);
                    // ukoliko su jednaka pocetna vremena nema potrebe gledati dalje
                    if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) == 0) {
                        System.Diagnostics.Debug.WriteLine(slot.StartTime + " == " + appointedDate);
                        filter = true;
                    }
                    // da li je slot time vreme pre appointed pocetnog vremena, ako jeste proveravamo slot end time (slot.StartTime + duration)
                    else if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) < 0) {
                        System.Diagnostics.Debug.WriteLine(slot.StartTime + " < " + appointedDate);
                        if (DateTime.Compare(Convert.ToDateTime(slot.StartTime).AddHours(duration), appointedDate) > 0)
                        {
                            System.Diagnostics.Debug.WriteLine(slot.StartTime + " +1h " + " > " + appointedDate);
                            filter = true;
                        }
                    } else if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) > 0)
                    {
                        System.Diagnostics.Debug.WriteLine(slot.StartTime + " > " + appointedDate);

                        if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate.AddHours(Convert.ToInt32(appointment.Duration))) < 0)
                        {
                            System.Diagnostics.Debug.WriteLine(slot.StartTime + " < " + appointedDate + " +" + Convert.ToInt32(appointment.Duration) + "h");
                            filter = true;
                        }
                    }

                    if (Convert.ToDateTime(slot.StartTime).Hour == 19 && appointmentType != "Operation") {
                        filter = true;
                    }

                    if (Convert.ToDateTime(slot.StartTime).AddHours(duration).Hour > 19 && appointmentType != "Operation")
                    {
                        filter = true;
                    }

                }
                if (!filter)
                {
                    filteredAppointments.Add(new MedicalAppointment(slot.StartTime, doctorId, duration));
                }
            }
        }


        // ------------------------------------------

        public List<MedicalAppointment> ScheduleEmergencyAppointment(int patientId, List<Doctor> specializedDoctors, string appointmentType)
        {
            return null;
        }


    }
}
