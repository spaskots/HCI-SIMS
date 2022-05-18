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
        RoomRepository roomRepository = new RoomRepository();
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
                    if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) == 0) {
                        filter = true;
                    }
                    else if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) < 0) {
                        if (DateTime.Compare(Convert.ToDateTime(slot.StartTime).AddHours(duration), appointedDate) > 0)
                        {
                            filter = true;
                        }
                    } else if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate) > 0)
                    {

                        if (DateTime.Compare(Convert.ToDateTime(slot.StartTime), appointedDate.AddHours(Convert.ToInt32(appointment.Duration))) < 0)
                        {
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

        public Boolean CheckDate(string startTime, double duration, string doctorId)
        {
            DateTime startDate = Convert.ToDateTime(startTime);
            List<MedicalAppointment> appointmentForDate = appointmentRepository.DoctorsAppointmentsAtDate(doctorId, startDate);

            foreach (MedicalAppointment appointment in appointmentForDate)
            {
                DateTime start = Convert.ToDateTime(appointment.StartTime);
                DateTime end = start.AddHours(duration);
                if (IsEqualDate(start, startDate)) return false;
                if (IsBeforeDate(startDate, start) && IsAfterDate(startDate.AddHours(duration), start)) return false;
                if (IsAfterDate(startDate, start) && IsBeforeDate(startDate, end)) return false;
            }
            return true;
        }

        public MedicalAppointment FindByAppointmentId(int id)
        {
            return appointmentRepository.FindByAppointmentId(id);
        }


        // ------------------------------------------

        public List<MedicalAppointment> ScheduleEmergencyAppointment(string patientId, List<Doctor> specializedDoctors, string appointmentType)
        {
            DateTime currentTime = DateTime.Now;
            int durationOfAppointment = (appointmentType == "examination" ? 1 : 2);
            List<MedicalAppointment> todaysAppointmentsForDoctors = DoctorsAppointmentsForDate(specializedDoctors, currentTime);

            if (todaysAppointmentsForDoctors.Count == 0)
            {
                Doctor doctor = specializedDoctors[0];
                AppointmentType type;
                Enum.TryParse(appointmentType.ToString(), out type);
                MedicalAppointment newAppointment = new MedicalAppointment(GenerateNewAppointmentId(),patientId, doctor.Id, currentTime.ToString(), durationOfAppointment, type);
                appointmentRepository.saveA(newAppointment);
            }
            
            var appointmentsGroupedByDoctors = todaysAppointmentsForDoctors.GroupBy(u => u.doctor.Id).Select(grp => grp.ToList()).ToList();
            List<MedicalAppointment> updatedAppointments = new List<MedicalAppointment>();

            MedicalAppointment firstAvailableAppointment = null;
            foreach (var appointmentForDoctor in appointmentsGroupedByDoctors)
            {
                firstAvailableAppointment = FindFirstAvailable(currentTime, durationOfAppointment, appointmentForDoctor);
                if (firstAvailableAppointment != null) break;
            }


            //MedicalAppointment firstAvailableAppointment = FindFirstAvailable(currentTime, durationOfAppointment, todaysAppointmentsForDoctors);
            //System.Diagnostics.Debug.WriteLine("Appointment: " + Convert.ToString(firstAvailableAppointment.StartTime));
            if (firstAvailableAppointment != null)
            {
                AppointmentType typeOfAppointment;
                Enum.TryParse(appointmentType.ToString(), out typeOfAppointment);
                firstAvailableAppointment.Type = typeOfAppointment;
                firstAvailableAppointment.Patient = firstAvailableAppointment.findPatient(patientId);
                firstAvailableAppointment.id = GenerateNewAppointmentId();
                appointmentRepository.saveA(firstAvailableAppointment);
                return null;
            } else
            {
                foreach (var appointmentsForDoctor in appointmentsGroupedByDoctors)
                {
                    updatedAppointments.AddRange(RescheduleAppointmentsForToday(appointmentsForDoctor, currentTime));
                }
            }
            return updatedAppointments.OrderBy(x => x.StartTime).ToList();
        }

        public List<MedicalAppointment> RescheduleAppointmentsForToday(List<MedicalAppointment> appointmentsForDoctor, DateTime currentTime)
        {
           
            appointmentsForDoctor = FilterOutdatedAppointments(appointmentsForDoctor, currentTime);

            MedicalAppointment updatedAppointment = null;
            List<MedicalAppointment> updatedSchedule = new List<MedicalAppointment>();
            foreach (var todaysAppointment in appointmentsForDoctor)
            {
                int daysMultiplier = 1;
                do
                {
                    updatedAppointment = FindFirstAvailable(currentTime.AddDays(1 * daysMultiplier), Convert.ToInt32(todaysAppointment.Duration), appointmentsForDoctor);
                    daysMultiplier++;
                } while (updatedAppointment == null);
                updatedSchedule.Add(updatedAppointment);
            }
            return updatedSchedule;
        }

        public List<MedicalAppointment> FilterOutdatedAppointments(List<MedicalAppointment> appointmentsForDoctor, DateTime currentTime)
        {
            List<MedicalAppointment> filteredAppointments = new List<MedicalAppointment> ();
            foreach (MedicalAppointment appointment in appointmentsForDoctor)
            {
                if (!IsBeforeDate(Convert.ToDateTime(appointment.StartTime), currentTime))
                {
                    filteredAppointments.Add(appointment);
                }
            }
            return filteredAppointments;
        }

        public List<MedicalAppointment> DoctorsAppointmentsForDate(List<Doctor> specializedDoctors, DateTime dateOfAppointment)
        {
            List<MedicalAppointment> appointmentsForToday = new List<MedicalAppointment>();
            List<MedicalAppointment> allAppointmentsToday = appointmentRepository.GetAllAppointmentsAtDate(dateOfAppointment);

            foreach (Doctor specializedDoctor in specializedDoctors)
            {   
                appointmentsForToday.AddRange(appointmentRepository.FindForDoctorAtDate(specializedDoctor, allAppointmentsToday));
            }
            return appointmentsForToday;
        }

       // public List<MedicalAppointment> GenerateTimeslots(DateTime startTime, DateTime endTime)


        public MedicalAppointment FindFirstAvailable (DateTime currentTime, int durationOfAppointment, List<MedicalAppointment> todaysAppointmentsForDoctors)
        {
            List<MedicalAppointment> timeslots = GeneratePossibleSlots(currentTime.Date, currentTime.AddDays(1).Date);
            currentTime = currentTime.AddHours(2); // testing purposes
            todaysAppointmentsForDoctors = todaysAppointmentsForDoctors.OrderBy(x => x.StartTime).ToList();

            bool filter;
            String doctorId = "";

            foreach (MedicalAppointment timeslot in timeslots)
            {
                if (DateTime.Compare(Convert.ToDateTime(timeslot.StartTime), currentTime.AddSeconds(-1)) < 0) continue;
                if (IsAfterDate(Convert.ToDateTime(timeslot.StartTime), currentTime.AddHours(1))) continue;
                filter = false;

                foreach (MedicalAppointment todaysAppointment in todaysAppointmentsForDoctors)
                {
                    DateTime startTime = Convert.ToDateTime(todaysAppointment.StartTime);
                    DateTime endTime = startTime.AddHours(todaysAppointment.Duration);
                    doctorId = todaysAppointment.doctor.Id;

                    if (filter || IsBeforeDate(endTime, Convert.ToDateTime(timeslot.StartTime))) continue;

                    if (IsEqualDate(Convert.ToDateTime(timeslot.StartTime), startTime))
                    {
                        filter = true;
                        continue;
                    }

                    if (IsBeforeDate(Convert.ToDateTime(timeslot.StartTime), startTime) &&
                        IsAfterDate(Convert.ToDateTime(timeslot.StartTime).AddHours(durationOfAppointment), startTime))
                    {
                        filter = true;
                        continue;
                    }
                    
                    if (IsAfterDate(Convert.ToDateTime(timeslot.StartTime), startTime) &&
                        IsBeforeDate(Convert.ToDateTime(timeslot.StartTime), endTime))
                    {
                        filter = true;
                        continue;
                    }

                }
                if (!filter)
                {
                    return new MedicalAppointment(Convert.ToString(timeslot.StartTime), doctorId, Convert.ToDouble(durationOfAppointment));
                }
            }
                
            return null;            
            }

        public Boolean IsBeforeDate(DateTime currentTime, DateTime date)
        {
            return DateTime.Compare(currentTime, date) < 0;
        }

        public Boolean IsAfterDate(DateTime currentTime, DateTime date)
        {
            return DateTime.Compare(currentTime, date) > 0;
        }

        public Boolean IsEqualDate(DateTime currentTime, DateTime date)
        {
            return DateTime.Compare(currentTime, date) == 0;
        }

        public int GenerateNewAppointmentId()
        {
            List<int> allIds = appointmentRepository.getAllId();
            return allIds.Count == 0 ? 0 : allIds.Last() + 1;
        }
    }
}
