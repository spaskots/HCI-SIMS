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

            System.Diagnostics.Debug.WriteLine(selectedSpecialization + "\n" + selectedType);
            System.Diagnostics.Debug.WriteLine(patient.Id + ": " + patient.Name + " " + patient.Surname);

            List<Doctor> specializedDoctors = _lekarController.FindBySpecialization(selectedSpecialization.ToString().ToLower());

            foreach (Doctor doctor in specializedDoctors)
            {
                System.Diagnostics.Debug.WriteLine("Dr." + doctor.Name + " " + doctor.Surname);
            }


            _appointmentController.ScheduleEmergencyAppointment(patient.Id, specializedDoctors, selectedType.ToString().ToLower());
        }
    }
}
