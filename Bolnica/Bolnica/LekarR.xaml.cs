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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for LekarR.xaml
    /// </summary>
    public partial class LekarR : Window
    {
        
        LekarController lekarController = new LekarController();
        RoomController roomController = new RoomController();
       

        public LekarR()
        {
            
            InitializeComponent();
            List<String> roomId=roomController.getAllId();
            foreach (String id in roomId)
            {
                Room.Items.Add(id);
            }
        }
        public bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }
        private void LekarR_Load(object sender,EventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            string name=Name.Text.ToString();
            string surname=Surname.Text.ToString();
            string phoneNumber=PhoneNumber.Text.ToString();
            String dateOfBirth =DATE.Text.ToString();
            string email=Email.Text.ToString();
            string id=Id.Text.ToString();
            string username=UserName.Text.ToString();
            string password=Password.Text.ToString();
            RegisteredUser ru = new RegisteredUser(username,password);
            string specialization=Specialization.Text.ToString();
            string licenseId=LicenseId.Text.ToString();
            //string salary=Salary.Text.ToString();
            
            String city = Grad.Text.ToString();
            String postalCode = PostalCode.Text.ToString();
            String idRoom=Room.Text.ToString();
            System.Collections.ArrayList lista_gradova = new System.Collections.ArrayList();
            Country drzava = new Country("Srbija", "SRB", lista_gradova);
            City grad = new City(city, postalCode, drzava);
            lista_gradova.Add(grad);

            Doctor noviDoktor = new Doctor(name, surname, dateOfBirth, phoneNumber, email, id, true, username, password, grad,specialization,licenseId,"null",idRoom);
            if(Name.Text=="" || Surname.Text=="" ||   PostalCode.Text==""|| PhoneNumber.Text=="" || !IsValidEmail(email) || UserName.Text=="" || Password.Text=="" || Id.Text.Length!=13  )
            {
                MessageBox.Show("Greska");
                return;
            }
            lekarController.LogIn(username, password);
            lekarController.saveDoctor(noviDoktor);
            this.Close();
            LekarPrijava lp = new LekarPrijava();
            lp.Show();
        }

        private void Salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
