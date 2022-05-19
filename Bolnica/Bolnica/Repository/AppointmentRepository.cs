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
        String lokacijaAppointment = @"..\..\..\Data\Termin.txt";
        public void save(MedicalAppointment ma)
        {
            String noviRed =ma.id+","+ma.StartTime +","+ma.Duration+","+ma.Type+","+ma.Patient.Id+","+ma.room.Id+","+ma.doctor.Id;
            StreamWriter write = new StreamWriter(lokacijaAppointment, true);
            write.WriteLine(noviRed);
            
            write.Close();
        }
        public void saveA(MedicalAppointment ma)
        {
            String noviRed = ma.id + "," + ma.StartTime + "," + ma.Duration + "," + ma.Type + "," + ma.Patient.Id + "," + "," + ma.doctor.Id;
            StreamWriter write = new StreamWriter(lokacijaAppointment, true);
            write.WriteLine(noviRed);

            write.Close();
        }
        public List<MedicalAppointment> GetAllAppointmentsByDoctorId(String ids)
        {
            List<MedicalAppointment> ma=new List<MedicalAppointment> ();
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (ids == fields[6])
                {
                    AppointmentType type;
                    Enum.TryParse(fields[3], out type);
                    MedicalAppointment maa = new MedicalAppointment(Convert.ToInt32(fields[0]), fields[4], fields[6], fields[1], Convert.ToDouble(fields[2]), type, fields[5]);
                    ma.Add(maa);
                }
            }
            return ma;
        }
        public void delete(MedicalAppointment ma)
        {
            String obrisiRed = ma.id + "," + ma.StartTime + "," + ma.Duration + "," + ma.Type + "," + ma.Patient.Id + "," + ma.room.Id + "," + ma.doctor.Id;

            String text = File.ReadAllText(lokacijaAppointment);
            if (text.Contains(obrisiRed))
            {
                text = text.Replace(obrisiRed, "");
                File.WriteAllText(lokacijaAppointment, text);
                var lines = File.ReadAllLines(lokacijaAppointment).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(lokacijaAppointment, lines);

            }
            
        }
        public MedicalAppointment GetOne(int id)
        {

            MedicalAppointment ma = null;
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                if (id == Convert.ToInt32(fields[0]))
                {
                    AppointmentType type;
                    Enum.TryParse(fields[3], out type);
                    ma = new MedicalAppointment(id, fields[4], fields[6], fields[1], Convert.ToDouble(fields[2]), type, fields[5]);
                    return ma;
                }
            }
            return ma;
        }
        public List<int> getAllId()
        {



            List<int> ids = new List<int>();
            ids.Clear();
           
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }


                int id = Convert.ToInt32(fields[0]);
                ids.Add(id);

            }
            return ids;
        }
        public void update(MedicalAppointment ma)
        {
            MedicalAppointment stari = this.GetOne(ma.id);
            String stariRed = stari.id + "," + stari.StartTime + "," + stari.Duration + "," + stari.Type + "," + stari.Patient.Id + "," + stari.room.Id + "," + stari.doctor.Id;
            String noviRed = ma.id + "," + ma.StartTime + "," + ma.Duration + "," + ma.Type + "," + ma.Patient.Id + "," + ma.doctor.Room.Id + "," + ma.doctor.Id;
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == stariRed)
                {
                    lines[i] = noviRed;
                    break;
                }
            }
            File.WriteAllLines(lokacijaAppointment, lines.ToArray());
        }

        public void updateE(MedicalAppointment ma)
        {
            MedicalAppointment stari = FindById(ma.id);
            String stariRed = stari.id + "," + stari.StartTime + "," + stari.Duration + "," + stari.Type + "," + stari.Patient.Id + "," + "," + stari.doctor.Id;
            String noviRed = ma.id + "," + ma.StartTime + "," + stari.Duration + "," + stari.Type + "," + stari.Patient.Id + "," + "," + stari.doctor.Id;
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == stariRed)
                {
                    lines[i] = noviRed;
                    break;
                }
            }
            File.WriteAllLines(lokacijaAppointment, lines.ToArray());
        }

        public MedicalAppointment FindById(int id)
        {
            string[] lines = File.ReadAllLines(lokacijaAppointment);

            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                if (line == "") { continue; }
                if (fields[0] == id.ToString())
                {
                    AppointmentType type;
                    Enum.TryParse(fields[3], out type);
                    MedicalAppointment appointment = new MedicalAppointment(Convert.ToInt32(fields[0]), fields[4], fields[6], fields[1], Convert.ToDouble(fields[2]), type);
                    return appointment;
                }
            }
            return null;
        }

        public MedicalAppointment FindByAppointmentId(int id)
        {
            return this.GetOne(id);
        }

        public List<MedicalAppointment> GetAllAppointments()
        {
            List<MedicalAppointment> appointments = new List<MedicalAppointment>();
            string[] lines = System.IO.File.ReadAllLines(lokacijaAppointment);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (line == "")
                {
                    continue;
                }

                AppointmentType type;
                Enum.TryParse(fields[3], out type);
                MedicalAppointment apointment = new MedicalAppointment(Convert.ToInt32(fields[0]), fields[4], fields[6], fields[1], Convert.ToDouble(fields[2]), type, fields[5]);
                appointments.Add(apointment);
            }
            return appointments;

        }
        
        public List<MedicalAppointment> ExtractTermsForDoctor (Doctor doctor, List<MedicalAppointment> allAppointmentsForDesiredDate)
        {
            List<MedicalAppointment> appointmentsForDesiredDoctor = new List<MedicalAppointment>();

            foreach (MedicalAppointment appointment in allAppointmentsForDesiredDate)
            {
                if (appointment.doctor.Id == doctor.Id)
                {
                    appointmentsForDesiredDoctor.Add(appointment);
                }
            }

            return appointmentsForDesiredDoctor;
        }

        public List<MedicalAppointment> GetAllAppointmentsAtDate(DateTime dateOfAppointment)
        {
            List<MedicalAppointment> allAppointments = GetAllAppointments();
            List<MedicalAppointment> appointmentsForDesiredDate = new List<MedicalAppointment>();
            foreach (MedicalAppointment appointment in allAppointments)
            {
                if (DateTime.Compare(Convert.ToDateTime(appointment.StartTime).Date, dateOfAppointment.Date) == 0)
                {
                    appointmentsForDesiredDate.Add(appointment);
                }

            }
            return appointmentsForDesiredDate;
        }

        public List<MedicalAppointment> GetAllDoctorsTermsAtDate(string doctorId, DateTime startDate)
        {
            List<MedicalAppointment> appointmentsAtDate = new List<MedicalAppointment>();
            List<MedicalAppointment> allDoctorsAppointments = GetAllAppointmentsByDoctorId(doctorId);

            foreach(MedicalAppointment appointment in allDoctorsAppointments)
            {
                if (Convert.ToDateTime(appointment.StartTime).Date == startDate.Date)
                {
                    appointmentsAtDate.Add(appointment);
                }
            }
            return appointmentsAtDate;
        }
    }
}

