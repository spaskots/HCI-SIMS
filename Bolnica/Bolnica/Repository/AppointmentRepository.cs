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
        public List<MedicalAppointment> getAllAppointment(String ids)
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
    }
    }

