using Bolnica.Controller;
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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for PatientOptions.xaml
    /// </summary>
    public partial class PatientOptions : Window
    {
        PatientController patientController = new PatientController();
        public PatientOptions()
        {
            InitializeComponent();
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
            string id = ID.Text.ToString();
            ReadPatient readPatient = new ReadPatient(id);
            readPatient.Show();

        }

        private void RemovePatient(object sender, RoutedEventArgs e)
        {
            string id = ID.Text.ToString();
            
            if (!patientController.DeleteById(id))
            {
                MessageBox.Show("Error Occured.");
                return;
            }

            MessageBox.Show("Successfully removed patient with JMBG: " + id);
        }
    }

   
}
