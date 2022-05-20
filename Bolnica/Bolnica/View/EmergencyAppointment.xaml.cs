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

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for EmergencyAppointment.xaml
    /// </summary>

    public partial class EmergencyAppointment : Window
    {
        private AppointmentController _appointmentController = new AppointmentController();
        private PatientController _patientController = new PatientController();
        private LekarController _lekarController = new LekarController();
        private AppointmentService _appointmentService = new AppointmentService();

        List<Patient> patients = new List<Patient>();
        public EmergencyAppointment()
        {
            InitializeComponent();
            patients = _patientController.getAllPatients();

            foreach (Patient patient in patients)
            {
                PatientCombo.Items.Add(patient.Id + " - " + patient.Name + " " + patient.Surname);
            }

            Specialization.Items.Add("Hirurg");
            Specialization.Items.Add("Opsta praksa");

            AppType.Items.Add("Examination");
            AppType.Items.Add("Operation");
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var selectedPatient = PatientCombo.SelectedIndex;
            var selectedSpecialization = Specialization.SelectedItem;
            var selectedType = AppType.SelectedItem;

            Patient patient = patients.ElementAt(selectedPatient);

            List<Doctor> specializedDoctors = _lekarController.FindBySpecialization(selectedSpecialization.ToString().ToLower());

            List<MedicalAppointment> updatedAppointments = _appointmentController.ScheduleEmergencyAppointment(patient.Id, specializedDoctors, selectedType.ToString().ToLower());

            if (updatedAppointments == null)
            {
                MessageBox.Show("Success: Emergency Appointment successfully scheduled!");
                this.Close();
            }
            else
            {
                EmergencyAppointmentTable eat = new EmergencyAppointmentTable(updatedAppointments, patient.Id, selectedType.ToString());
                eat.Show();
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
