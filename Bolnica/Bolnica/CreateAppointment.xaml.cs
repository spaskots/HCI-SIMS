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
        RoomController roomController = new RoomController();
        PatientController patientController = new PatientController();

        public CreateAppointment()
        {
            InitializeComponent();
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
            String id=ID.Text.ToString();
            String startTime = StartTime.Text.ToString();
            Double duration;
            Double.TryParse(Duration.Text, out duration);           
            
            String idPacijenta=PatientId.Text.ToString();
            String idSobe = RoomId.Text.ToString();
            String idDoktora = DoctorId.Text.ToString();
            AppointmentType type;

            Enum.TryParse(TypeId.Text.ToString(), out type);
            MedicalAppointment ma = new MedicalAppointment(id, idPacijenta, idDoktora, startTime, duration, type, idSobe);
            if(ID.Text=="" || StartTime.Text=="" || Duration.Text=="" || PatientId.Text=="" || RoomId.Text=="" || DoctorId.Text=="")
            {
                MessageBox.Show("Greska");
                return;
            }
            appointmentController.save(ma);
            LekarPocetna lp=new LekarPocetna();
            lp.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }
    }
}
