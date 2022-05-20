using System;
using System.Windows;
using Bolnica.Controller;
using Bolnica.Table;

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for PatientOptions.xaml
    /// </summary>
    public partial class PatientOptions : Window
    {
        PatientController patientController = new PatientController();
        OrderController _orderController = new OrderController();

        public PatientOptions()
        {
            InitializeComponent();
            _orderController.CheckOrders();
        }

        private void AddPatientWin(object sender, RoutedEventArgs e)
        {
            AddPatient addPatients = new AddPatient();
            addPatients.Show();
        }

        private void AddGuestWin(object sender, RoutedEventArgs e)
        {
            AddGuestPatient addGuestPatients = new AddGuestPatient();
            addGuestPatients.Show();
        }

        private void ReadPatientWin(object sender, RoutedEventArgs e)
        {
            string id = "0";
            ReadPatient readPatient = new ReadPatient(id);
            readPatient.Show();

        }

        private void ViewPatientWin(object sender, RoutedEventArgs e)
        {
            ViewPatients viewPatient = new ViewPatients();
            viewPatient.Show();
        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            string id = "0";
            
            if (!patientController.DeleteById(id))
            {
                MessageBox.Show("Error Occured.");
                return;
            }

            MessageBox.Show("Successfully removed patient with JMBG: " + id);
        }

        private void ViewAppointmentWin(object sender, RoutedEventArgs e)
        {
            ViewAllAppointments viewAppointments = new ViewAllAppointments();
            viewAppointments.Show();
        }

        private void PriorityAppointmentWin(object sender, RoutedEventArgs e)
        {
            PriorityAppointment priority = new PriorityAppointment();
            priority.Show();
        }

        private void EmergencyAppointmentWin(object sender, RoutedEventArgs e)
        {
            EmergencyAppointment emergencyAppointment= new EmergencyAppointment();
            emergencyAppointment.Show();
        }

        private void OrderEquipment(object sender, RoutedEventArgs e)
        {
            OrderDynamicEquipment orderEquipment = new OrderDynamicEquipment();
            orderEquipment.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            menuItem.IsSubmenuOpen = false;
        }
    }
}
