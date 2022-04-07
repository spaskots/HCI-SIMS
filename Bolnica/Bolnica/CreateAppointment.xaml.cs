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

        public CreateAppointment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String id=ID.Text.ToString();
            String startTime=StartTime.Text.ToString();
            double duration=Convert.ToDouble(Duration.Text.ToString());
            AppointmentType type;
            Enum.TryParse(Type.Text, out type);
            String idPacijenta=Patient.Text.ToString();
            String idSobe=Room.Text.ToString();
            String idDoktora=Doctor.Text.ToString();
            MedicalAppointment ma = new MedicalAppointment(id, idPacijenta, idDoktora, startTime, duration, type, idSobe);
            appointmentController.save(ma);
        }
    }
}
