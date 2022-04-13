using Bolnica.Controller;
using Bolnica.Model;
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
    /// Interaction logic for AddGuestPatient.xaml
    /// </summary>
    public partial class AddGuestPatient : Window
    {
        PatientController patientController = new PatientController();

        public AddGuestPatient()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text.ToString();
            string surname = Surname.Text.ToString();
            string id = ID.Text.ToString();

            Patient patient = new Patient(name, surname, id);
            
            if (!patientController.AddGuest(patient))
            {
                MessageBox.Show("Error: Patient with given JMBG already exists.");
                return;
            }

            MessageBox.Show("Successfully added: " + name + " " + surname + " as guest account.");
            this.Close();

        }
    }
}
