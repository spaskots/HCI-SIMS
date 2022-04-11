using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bolnica.Model;
using Bolnica.Controller;
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for LekarPocetna.xaml
    /// </summary>
    public partial class LekarPocetna : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        LekarController lekarController = new LekarController();
        RoomController roomController = new RoomController();
        PatientController patientController = new PatientController();
        public LekarPocetna()
        {
            InitializeComponent();
            String username = LekarPrijava.SetValueForUsername;
            Doctor doctor = lekarController.GetOneByUsername(username);
            List<MedicalAppointment> ma = appointmentController.getAllAppointment(doctor.Id);
            foreach (MedicalAppointment m in ma)
            {

                MedicalAppointmentView.Items.Add(m);
            }
            List<String> doctorId = lekarController.getAllId();
            List<String> roomId = roomController.getAllId();
            List<String> patientId = patientController.getAllId();
            foreach (String id in doctorId)
            {
                DoctorId.Items.Add(id);
            }
            foreach (String id in roomId)
            {
                RoomId.Items.Add(id);
            }
            foreach (String id in patientId)
            {
                PatientId.Items.Add(id);
            }
            TypeId.Items.Add(0);
            TypeId.Items.Add(1);
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment ca=new CreateAppointment();
            ca.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        private void delete_Click(object sender,RoutedEventArgs e)
        {
            MedicalAppointment ma=MedicalAppointmentView.SelectedItem as MedicalAppointment;
            appointmentController.delete(ma);
            this.Close();
            LekarPocetna lp = new LekarPocetna();
            lp.Show();
        }
        private void change_Click(object sender,RoutedEventArgs e)
        {
            MedicalAppointment ma = MedicalAppointmentView.SelectedItem as MedicalAppointment;
            ID.Text=ma.Id.ToString();
            STARTTIME.Text=ma.StartTime.ToString();
            DURATION.Text=ma.Duration.ToString();
            PatientId.Text=ma.Patient.Id.ToString();
            DoctorId.Text=ma.doctor.Id.ToString();
            RoomId.Text=ma.room.Id.ToString();
            TypeId.Text = "0";
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String id = ID.Text;
            String startTime=STARTTIME.Text.ToString();
            double duration=Convert.ToDouble(DURATION.Text);
            String patientId=PatientId.Text;
            String doctorId=DoctorId.Text;
            String roomId=RoomId.Text;
            AppointmentType type;
            Enum.TryParse(TypeId.Text.ToString(), out type);
            MedicalAppointment ma = new MedicalAppointment(id, patientId, doctorId, startTime, duration, type, roomId);
            appointmentController.update(ma);
            this.Close();
            LekarPocetna lp = new LekarPocetna();
            lp.Show();

        }

        private void Make_an_appointment_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment ca=new CreateAppointment();
            ca.Show();
        }

        private void MedicalAppointmentView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
