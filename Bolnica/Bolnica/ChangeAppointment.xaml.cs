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
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for ChangeAppointment.xaml
    /// </summary>
    public partial class ChangeAppointment : Window
    {
        LekarController lekarController=new LekarController();
        RoomController roomController=new RoomController();
        PatientController patientController=new PatientController(); 
        AppointmentController appointmentController=new AppointmentController();
        public ChangeAppointment()
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
            
            STARTTIME.Text = LekarPocetna.ma.StartTime.ToString();
            DURATION.Text = LekarPocetna.ma.Duration.ToString();
            PatientId.Text = LekarPocetna.ma.Patient.Id.ToString();
            DoctorId.Text = LekarPocetna.ma.doctor.Id.ToString();
            TypeId.Text = "0";
            STARTTIME.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            String startTime = STARTTIME.Text.ToString();
            double duration = Convert.ToDouble(DURATION.Text);
            String patientId = PatientId.Text;
            String doctorId = DoctorId.Text;
            AppointmentType type;
            Enum.TryParse(TypeId.Text.ToString(), out type);
            MedicalAppointment ma = new MedicalAppointment( patientId, doctorId, startTime, duration, type);
           
            if (MessageBox.Show("Are you sure you want to change the appointment?", "Delete appointment", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                appointmentController.update(ma);
                LekarPocetna lp = new LekarPocetna();
                lp.Show();
                this.Close();
            }
            else
            {
               
                
            }
          
        }

       
        private void Button_KeyDown(object sender,KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Button_Click_1(sender, e);
            }
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LekarPocetna lp = new LekarPocetna();
            lp.Show();
            this.Close();
        }
    }
    }

