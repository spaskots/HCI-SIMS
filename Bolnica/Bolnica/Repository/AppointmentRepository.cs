using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Model;
namespace Bolnica.Repository
{
    public class AppointmentRepository
    {
        String lokacijaAppointment = @"C:\Users\Korisnik\Desktop\SIMS Projekat\HCI-SIMS\Bolnica\Termin.txt";
        public void save(MedicalAppointment ma)
        {
            String noviRed =ma.Id +","+ma.StartTime +","+ma.Duration+","+ma.Type+","+ma.Patient.Id+","+ma.room.Id+","+ma.doctor.Id;
            StreamWriter write = new StreamWriter(lokacijaAppointment, true);
            write.WriteLine(noviRed);
            write.Close();
        }
        public List<MedicalAppointment> getAllAppointment()
        {
            List<MedicalAppointment> ma = new List<MedicalAppointment>();

            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                string id = fields[0];
                string starttime = fields[1];
                double duration = Convert.ToDouble(fields[2]);
               AppointmentType type;
                Enum.TryParse(fields[3], out type);
                string patientId = fields[4];
                string roomId = fields[5];
                string doctorId = fields[6];
                MedicalAppointment maa = new MedicalAppointment(id, patientId, doctorId, starttime, duration, type, roomId);
                ma.Add(maa);
            }
            return ma;
        }
    }
    }

