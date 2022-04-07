using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Service;
namespace Bolnica.Model
{
   

    public class Doctor : User
    {
        public void AddMedicalAppointment()
        {
            // TODO: implement
        }

        public void RemoveMedicalAppointment()
        {
            // TODO: implement
        }

        public void RemoveAllMedicalAppointment()
        {
            // TODO: implement
        }

        public Room FindRoom(String id)
        {
            // TODO: implement
            return null;
        }

        public void ChangeMedicalAppointment()
        {
            // TODO: implement
        }

        public String Specialization { set; get; }
        public String LicenseId { set; get; }
        public String Salary { set; get; }

        public System.Collections.ArrayList medicalAppointment;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetMedicalAppointment()
        {
            if (medicalAppointment == null)
                medicalAppointment = new System.Collections.ArrayList();
            return medicalAppointment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetMedicalAppointment(System.Collections.ArrayList newMedicalAppointment)
        {
            RemoveAllMedicalAppointment();
            foreach (MedicalAppointment oMedicalAppointment in newMedicalAppointment)
                AddMedicalAppointment(oMedicalAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddMedicalAppointment(MedicalAppointment newMedicalAppointment)
        {
            if (newMedicalAppointment == null)
                return;
            if (this.medicalAppointment == null)
                this.medicalAppointment = new System.Collections.ArrayList();
            if (!this.medicalAppointment.Contains(newMedicalAppointment))
            {
                this.medicalAppointment.Add(newMedicalAppointment);
                newMedicalAppointment.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveMedicalAppointment(MedicalAppointment oldMedicalAppointment)
        {
            if (oldMedicalAppointment == null)
                return;
            if (this.medicalAppointment != null)
                if (this.medicalAppointment.Contains(oldMedicalAppointment))
                {
                    this.medicalAppointment.Remove(oldMedicalAppointment);
                    oldMedicalAppointment.SetDoctor((Doctor)null);
                }
        }

        public Room Room { get; set; }

        public Doctor(string name, string surname, String dateOfBirth, string phoneNumber, string email, string id, bool active, string username, string password, City city,string specialization,string licenseId,string salary,string idRoom) : base(name, surname, dateOfBirth, phoneNumber, email, id, active, username, password, city)
        {
            Specialization= specialization;
            LicenseId= licenseId;
            Salary= salary;
            Room = findRoomById(idRoom);
            this.Room = Room;
        }
        public Doctor(string name, string surname, String dateOfBirth, string phoneNumber, string email, string id, bool active, string username, string password, City city) : base(name, surname, dateOfBirth, phoneNumber, email, id, active, username, password, city)
        {
            
        }
        public Room findRoomById(String id)
        {
            Room roomFound = new Room();
            RoomService roomService=new RoomService();
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
