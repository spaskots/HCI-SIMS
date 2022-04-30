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
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        AppointmentController appointmentController=new AppointmentController();
        LekarController lekarController=new LekarController();
        PatientController patientController = new PatientController();
        AutoIncrementController autoIncrementController = new AutoIncrementController();
        List<int> medicalAppointmentId = null;
        MedicalAppointment ma = null;

        public CreateAppointment()
        {
            InitializeComponent();
            List<String> doctorId = lekarController.getAllId();
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
            STARTTIME.Focus();
            DoctorId.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            medicalAppointmentId = appointmentController.getAllId();
            int id;
            String startTime = STARTTIME.Text.ToString();
            Double duration;
            Double.TryParse(DURATION.Text, out duration);

            String idPacijenta = PatientId.Text.ToString();

            String idDoktora = DoctorId.Text.ToString();

            AppointmentType type;

            Enum.TryParse(TypeId.Text.ToString(), out type);
            if (medicalAppointmentId == null)
            {
                id = 0;
            }
            else
            {
                id = medicalAppointmentId.Last();
                ++id;
            }
            ma = new MedicalAppointment(id, idPacijenta, idDoktora, startTime, duration, type);
            Doctor d = ma.findDoctor(idDoktora);


            Room r = ma.findRoom(d.Room.Id);


            ma.SetRoom(r);
            if (STARTTIME.Text == "" || DURATION.Text == "" || PatientId.Text == "" || DoctorId.Text == "")
            {
                MessageBox.Show("Greska");
                return;
            }
            appointmentController.save(ma);
            LekarPocetna lp = new LekarPocetna();
            lp.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        
        private void Button_KeyDown(object sender,KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
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
