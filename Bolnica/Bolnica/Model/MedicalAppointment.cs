using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bolnica.Service;

namespace Bolnica.Model
{


    public class MedicalAppointment
    {

        public int id { get; set; } 

        public String StartTime { set; get; }
        public double Duration { set; get; }
        public AppointmentType Type { set; get; }
        public Patient Patient { set; get; }

        public Room room { set; get; }
        public Doctor doctor { set; get; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return doctor;
        }
        
        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveMedicalAppointment(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddMedicalAppointment(this);
                }
            }
        }
        public void SetRoom(Room r)
        {
            this.room = r;
        }
        
        public MedicalAppointment( string patientId, string doctorId, String startTime, double duration, AppointmentType type)

        {

            this.id = id;
            this.doctor = findDoctor(doctorId);
            this.Patient = findPatient(patientId);
            this.StartTime = startTime;
            this.Duration = duration;
            this.Type = type;
           

        }
        public MedicalAppointment( int id,string patientId, string doctorId, String startTime, double duration, AppointmentType type,string roomId)

        {
            
            this.id = id;
            this.doctor = findDoctor(doctorId);
            this.Patient = findPatient(patientId);
            this.room=findRoom(roomId);
            this.StartTime = startTime;
            this.Duration = duration;
            this.Type = type;

        }
        public Doctor findDoctor(string id)
        {
            Doctor doctor = null;
            LekarService lekarService = new LekarService();
            List<Doctor> lekari =lekarService.getAllDoctors();
            foreach (Doctor l in lekari)
            {
                if (l.Id==id)
                {
                    doctor = l;
                    break;
                }
            }
            return doctor;
        }
        public Patient findPatient(string id)
        {
            Patient patient = null;
            PatientService patientService = new PatientService();
            List<Patient> pacijenti = patientService.getAllPatient();
            foreach (Patient p in pacijenti)
            {
                if (p.Id==id)
                {
                    patient = p;
                    break;
                }
            }
            return patient;
        }


        public Room findRoom(string id)
        {
            Room roomFound = new Room();
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.getAllRooms();
            foreach (Room r in rooms)
            {
                if (r.Id == id)
                {
                    roomFound = r;
                    break;
                }
            }
            return roomFound;
        }

    }
}
