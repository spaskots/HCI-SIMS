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
using System.Collections.ObjectModel;
using Bolnica.Model;
using Bolnica.Controller;
using System.Collections;

namespace Bolnica.Table
{
    /// <summary>
    /// Interaction logic for ViewPatients.xaml
    /// </summary>
    /// 

    public partial class ViewPatients : Window
    {

        PatientController patientController = new PatientController();

        public ObservableCollection<Patient> Patients
        {
            get; set;
        }


        public ViewPatients()
        {
            InitializeComponent();
            this.DataContext = this;
            Patients = new ObservableCollection<Patient>();
            List<Patient> allPatients = new List<Patient>();
            allPatients = patientController.getAllPatients();

            foreach (Patient pat in allPatients)
            {
                Patients.Add(new Patient() {Id = pat.Id, Name = pat.Name, Surname =pat.Surname,
                                            Email = pat.Email, PhoneNumber = pat.PhoneNumber,
                                            Active = pat.Active});
            }
        }

        public void EditPatient()
        {
            Patient patient = dataGridPatients.SelectedItem as Patient;

            if (patient == null) return;
        }


        public void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
           /* var obj = dataGridPatients.SelectedItems;
            
            //List<string> ids = new List<string>();

            foreach (var pat in obj)
            {
                Patient patient = (Patient)pat;
                patientController.DeleteById(patient.Id);
                //ids.Add(patient.Id);
            }
           */

        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            Patient patient = (Patient)dataGridPatients.SelectedItem;
            if (MessageBox.Show("Are you sure you want to delete this patient?", "Delete patient", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                patientController.DeleteById(patient.Id);
                Patients.RemoveAt(Patients.Count - 1);
                //ViewPatients vp = new ViewPatients();
                //this.Close();
                //vp.Show();
            }
            
            /*var obj = dataGridPatients.SelectedItems;

            if (obj == null) return;

            foreach (var pat in obj)
            {
                Patient patient = (Patient)pat;
                patientController.DeleteById(patient.Id);
            }*/
        }

        public void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)dataGridPatients.SelectedItem;
            ReadPatient readPat = new ReadPatient(patient.Id);
            readPat.Show();
            this.Close();
        }

        private void MedicalCard_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)dataGridPatients.SelectedItem;
            MedicalCardAllergen medCard = new MedicalCardAllergen(patient.Id);
            medCard.Show();
            //this.Close();
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            AddPatient addPatientWin = new AddPatient();
            addPatientWin.Show();
            //this.Close();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
