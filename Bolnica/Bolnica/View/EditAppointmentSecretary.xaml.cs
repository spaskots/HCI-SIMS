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
using Bolnica.Controller;
using Bolnica.Model;
using Bolnica.View;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for ChangeAppointment.xaml
    /// </summary>
    public partial class EditAppointmentSecretary : Window
    {
        LekarController lekarController=new LekarController();
        RoomController roomController=new RoomController();
        PatientController patientController=new PatientController(); 
        AppointmentController appointmentController=new AppointmentController();
        public EditAppointmentSecretary()
        {
            InitializeComponent();
            List<String> doctorId = lekarController.getAllId();
            List<String> roomId = roomController.getAllId();
            List<String> patientId = patientController.getAllId();
            foreach (String id in doctorId)
            {
                DoctorId.Items.Add(id);
            }
            foreach (String id in patientId)
            {
                PatientId.Items.Add(id);
            }
            TypeId.Items.Add(0);
            TypeId.Items.Add(1);
            
            STARTTIME.Text = ViewAllAppointments.appoint.StartTime.ToString();
            DURATION.Text = ViewAllAppointments.appoint.Duration.ToString();
            PatientId.Text = ViewAllAppointments.appoint.Patient.Id.ToString();
            DoctorId.Text = ViewAllAppointments.appoint.doctor.Id.ToString();
            TypeId.Text = "0";
            STARTTIME.Focus();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
           
            String startTime = STARTTIME.Text.ToString();
            double duration = Convert.ToDouble(DURATION.Text);
            String patientId = PatientId.Text;
            String doctorId = DoctorId.Text;
            AppointmentType type;
            Enum.TryParse(TypeId.Text.ToString(), out type);
            int id = ViewAllAppointments.appoint.id;

            MedicalAppointment ma = new MedicalAppointment(patientId, doctorId, startTime, duration, type);
            ma.id = id;
            if (MessageBox.Show("Are you sure you want to change the appointment?", "Delete appointment", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                appointmentController.update(ma);
                ViewAllAppointments vap = new ViewAllAppointments();
                vap.Show();
                this.Close();
            }         
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ViewAllAppointments vap = new ViewAllAppointments();
            vap.Show();
            this.Close();
        }
    }
    }

