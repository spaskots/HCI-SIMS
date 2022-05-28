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
using Bolnica.View;

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

            //Password.PasswordChar = '*';
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

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            string id = Jmbg.Text.ToString(); // JMBG

            string fullname = Fullname.Text.ToString();

            string[] names = fullname.Split();
            if (names.Length < 2 ) { MessageBox.Show("Warning: Fullname field isn't filled correctly!"); return; }
            string name = names[0];
            string surname = names[1];
            string dateOfBirth = Birthday.Text.ToString();

            string phoneNumber = Phone.Text.ToString();
            string email = Email.Text.ToString();
            if (guestCheck.Equals(false)) { 
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
            }

            string username = Username.Text.ToString();
            string password = Password.Password.ToString();
            Patient patient = new Patient();

            if (guestCheck.Equals(true))
            {
                patient = new Patient(name, surname, id);
                if (!patientController.AddGuest(patient))
                {
                    MessageBox.Show("Patient with given JMBG: " + id + " already exists.");
                    return;
                }
            } else
            {
                patient = new Patient(name, surname, dateOfBirth, phoneNumber, email, id, true, username, password);
                if (!patientController.Add(patient))
                {
                    MessageBox.Show("Patient with given JMBG: " + id + " already exists.");
                    return;
                }
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
            MedCard medicalCard = new MedCard(idmc, patient, null,null);
            medicalCardController.save(medicalCard);
            this.Close();
        }

        private void Cancel_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool famState = true;
        private bool jmbgState = true;
        private bool bdayState = true;
        private bool emailState = true;
        private bool userState = true;
        private bool phoneState = true;

        private string famRet = string.Empty;
        private string jmbgRet = string.Empty;
        private string bdayRet = string.Empty;
        private string emailRet = string.Empty;
        private string userRet = string.Empty;
        private string phoneRet = string.Empty;

        private void Fullname_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (famState)
            {
                famRet = textBox.Text;
                textBox.Text = string.Empty;
                famState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = famRet;
                    famState = true;
                }
            }
        }

        private void Jmbg_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (jmbgState)
            {
                jmbgRet = textBox.Text;
                textBox.Text = string.Empty;
                jmbgState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = jmbgRet;
                    jmbgState = true;
                }
            }
        }

        private void Birthday_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (bdayState)
            {
                bdayRet = textBox.Text;
                textBox.Text = string.Empty;
                bdayState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = bdayRet;
                    bdayState = true;
                }
            }
        }

        private void Email_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (emailState)
            {
                emailRet = textBox.Text;
                textBox.Text = string.Empty;
                emailState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = emailRet;
                    emailState = true;
                }
            }
        }

        private void Username_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (userState)
            {
                userRet = textBox.Text;
                textBox.Text = string.Empty;
                userState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = userRet;
                    userState = true;
                }
            }
        }

        private void Phone_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (phoneState)
            {
                phoneRet = textBox.Text;
                textBox.Text = string.Empty;
                phoneState = false;
            }
            else
            {
                if (textBox.Text == string.Empty)
                {
                    textBox.Text = phoneRet;
                    phoneState = true;
                }
            }
        }

        private bool guestCheck = false;
        private void GuestBox_Change (object sender, RoutedEventArgs e)
        {
            guestCheck = !guestCheck;
            Email.IsEnabled = !guestCheck;
            Username.IsEnabled = !guestCheck;
            Password.IsEnabled = !guestCheck;
            Phone.IsEnabled = !guestCheck;
        }

        /*private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == string.Empty)
            {
                textBox.Text = textRet;
                initState = true;
            }
        }*/

    }
}
