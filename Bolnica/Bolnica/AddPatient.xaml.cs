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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        PatientController patientController = new PatientController();
        MedicalCardController medicalCardController=new MedicalCardController();
        List<int> medicalReportId = null;
        public AddPatient()
        {
            InitializeComponent();

            Password.PasswordChar = '*';
        }
        public bool IsValidEmail(string source)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(source, pattern);
        }

        public bool IsValidPhone(string source)
        {
            string pattern = @"(\+?( |-|\.)?\d{1,2}( |-|\.)?)?(\(?\d{3}\)?|\d{3})( |-|\.)?(\d{3}( |-|\.)?\d{4})";
            return Regex.IsMatch(source, pattern);
        }

        public bool isValidDate(string source)
        {
            string pattern = @"^(((0[1-9]|[12][0-9]|3[01])[- /.](0[13578]|1[02])|(0[1-9]|[12][0-9]|30)[- /.](0[469]|11)|(0[1-9]|1\d|2[0-8])[- /.]02)[- /.]\d{4}|29[- /.]02[- /.](\d{2}(0[48]|[2468][048]|[13579][26])|([02468][048]|[1359][26])00))$";
            return Regex.IsMatch(source, pattern);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.ArrayList lista_gradovaS = new System.Collections.ArrayList();
            System.Collections.ArrayList lista_gradovaB = new System.Collections.ArrayList();
            System.Collections.ArrayList lista_gradovaA = new System.Collections.ArrayList();
            lista_gradovaS.Add("Novi Sad");
            lista_gradovaS.Add("Beograd");
            lista_gradovaB.Add("Banja Luka");
            lista_gradovaB.Add("Sarajevo");
            lista_gradovaA.Add("Salzburg");
            lista_gradovaA.Add("Bec");

            Country serbia = new Country("Serbia", "SRB", lista_gradovaS);
            Country bosnia = new Country("Bosnia and Herzegovina", "BIH", lista_gradovaB);
            Country austria= new Country("Austria", "AU", lista_gradovaA);


            string id = ID.Text.ToString(); // JMBG
            string name = Name.Text.ToString();
            string surname = Surname.Text.ToString();
            string dateOfBirth = Birthday.Text.ToString();
            string phoneNumber = PhoneNumber.Text.ToString();
            string email = Email.Text.ToString();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Error: Invalid mail. (mail@example.com)");
                return;
            }
            if (!IsValidPhone(phoneNumber))
            {
                MessageBox.Show("Error: Invalid phone number.");
                return;
            }
            if (!isValidDate(dateOfBirth))
            {
                MessageBox.Show("Error: Invalid date format (DD/MM/YYYY).");
                return;
            }

            string username = Username.Text.ToString();
            string password = Password.Password.ToString();

            string country = Country.Text.ToString();
            string city = City.Text.ToString();
            string postalCode = PostalCode.Text.ToString();

            City cityObj = new City(city, postalCode);
            Country countryObj = null;
            if (country == "Serbia") { countryObj = serbia; }
            if (country == "Bosnia") { countryObj = bosnia; }
            if (country == "Austria") { countryObj = austria; }
            if (countryObj == null)
            {
                MessageBox.Show("Error: Country can't be empty!");
                return;
            }
            cityObj.SetCountry(countryObj);
            Patient newPatient = new Patient(name, surname, dateOfBirth, phoneNumber, email, id, true, username, password, cityObj);
            
            
            if (!patientController.Add(newPatient))
            {
                MessageBox.Show("Patient with given JMBG: " + id + " already exists.");
                return;
            }

            MessageBox.Show("Successfully created patient: " + name + " " + surname);

            medicalReportId = medicalCardController.getAllId();
            int idmc;
            if (medicalReportId == null)
            {
                idmc = 0;
            }
            else
            {
                idmc = medicalReportId.Last();
                ++idmc;
            }
            MedCard medicalCard = new MedCard(idmc, newPatient,null,null);
            medicalCardController.save(medicalCard);
            this.Close();
        }
    }
}
