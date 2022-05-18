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
using Bolnica.Service;
using Bolnica.Repository;

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for EmergencyAppointmentTable.xaml
    /// </summary>
    public partial class EmergencyAppointmentTable : Window
    {
        AppointmentController _appointmentController = new AppointmentController();
        private AppointmentService _appointmentService = new AppointmentService();
        private AppointmentRepository _appointmentRepository = new AppointmentRepository();
        MedicalAppointment emergencyAppointment = null;
        public EmergencyAppointmentTable(List<MedicalAppointment> updatedAppointments, string patientId, string type)
        {
            InitializeComponent();
            foreach (var appointment in updatedAppointments)
            {
                MedicalAppointmentView.Items.Add(appointment);
            }

            var duration = type.ToLower() == "examination" ? 1 : 2;
            AppointmentType appointmentType;
            Enum.TryParse(type.ToString(), out appointmentType);

            emergencyAppointment = new MedicalAppointment(_appointmentService.GenerateNewAppointmentId(), patientId, "", "", duration, appointmentType);
        }

        public void change_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment appointmentToReschedule = (MedicalAppointment)MedicalAppointmentView.SelectedItem;

            if (MessageBox.Show("Are you sure you want to reschedule the appointment?", "Reschedule appointment", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Debug.WriteLine("id:" + appointmentToReschedule.id);
                appointmentToReschedule.id = 1;
                _appointmentRepository.updateE(appointmentToReschedule);
                emergencyAppointment.SetDoctor(appointmentToReschedule.doctor);
                emergencyAppointment.StartTime = appointmentToReschedule.StartTime;
                _appointmentRepository.saveA(emergencyAppointment);
            }
        }
    }
}
