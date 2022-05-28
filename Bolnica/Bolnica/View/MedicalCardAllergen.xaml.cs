using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Bolnica.Controller;
using Bolnica.Model;

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for MedicalCardAllergen.xaml
    /// </summary>
    public partial class MedicalCardAllergen : Window
    {

        AllergenController allergenController = new AllergenController();
        PatientController patientController = new PatientController();

        public string Ids { get; set; }
        public ObservableCollection<Allergen>? Allergens { get; set; }
        public MedicalCardAllergen(string id)
        {
            this.Ids = id;
            InitializeComponent();

            Patient patient = patientController.FindById(Ids);
            this.DataContext = this;

            if (patient == null) { MessageBox.Show("Error: Couldn't find the user with given JMBG!"); return; }
            else
            {
                Fullname.Text = patient.Name + " " + patient.Surname;
                Id.Text = patient.Id;

                Allergens = new ObservableCollection<Allergen>();
                List<Allergen> allPatientAllergens = new List<Allergen>();
                allPatientAllergens = allergenController.GetAllByPatientId(patient.Id);

                foreach (Allergen allergen in allPatientAllergens)
                {
                    Allergens.Add(new Allergen() { Name = allergen.Name });
                }

                List<Allergen> allAllergens = new List<Allergen>();
                allAllergens = allergenController.GetAllNoRepeat(allPatientAllergens);

                foreach (Allergen allergen in allAllergens)
                {
                    AllergenId.Items.Add(allergen.Name);
                }

            }
        }

        public void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            Allergen allergen = (Allergen)dataGridAllergen.SelectedItem;
            allergenController.DeleteByPatientId(Ids, allergen.Name);
            Allergens.RemoveAt(dataGridAllergen.SelectedIndex);
        }

        public void AddAllergen(object sender, RoutedEventArgs e)
        {
            string patientId = Ids;
            string allergenName = AllergenId.Text.ToString();

            allergenController.AddForPatient(patientId, allergenName);
            Allergens.Add(new Allergen(8, allergenName));

            
            

            //this.Close();
            //MedicalCardAllergen medCard = new MedicalCardAllergen(Ids);
           // medCard.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
