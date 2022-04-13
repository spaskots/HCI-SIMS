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
    /// 
    public partial class LekarR : Window
    {
        
        LekarController lekarController = new LekarController();
        RoomController roomController = new RoomController();
        

        public LekarR()
        {
            
            InitializeComponent();
            
            
            Password.PasswordChar = '*';
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
            System.Collections.ArrayList lista_gradovaS = new System.Collections.ArrayList();
            System.Collections.ArrayList lista_gradovaB = new System.Collections.ArrayList();
            System.Collections.ArrayList lista_gradovaA = new System.Collections.ArrayList();
            lista_gradovaS.Add("Novi Sad");
            lista_gradovaS.Add("Beograd");
            lista_gradovaB.Add("Banja Luka");
            lista_gradovaB.Add("Sarajevo");
            lista_gradovaA.Add("Salzburg");
            lista_gradovaA.Add("Bec");
            Country srbija = new Country("Srbija", "SRB", lista_gradovaS);
            Country bosna = new Country("Bosna", "BIH", lista_gradovaB);
            Country austrija = new Country("Austrija", "AU", lista_gradovaA);
            string name=Name.Text.ToString();
            string surname=Surname.Text.ToString();
            string phoneNumber=PhoneNumber.Text.ToString();
            String dateOfBirth =DATE.Text.ToString();
            string email=Email.Text.ToString();
            string id=Id.Text.ToString();
            string username=UserName.Text.ToString();
            string password=Password.Password.ToString();
            RegisteredUser ru = new RegisteredUser(username,password);
            string specialization=Specialization.Text.ToString();
            string licenseId=LicenseId.Text.ToString();
            //string salary=Salary.Text.ToString();
            String drzava = Drzava.Text.ToString();
            String grad=GRAD.Text.ToString();
            String postalCode = PostalCode.Text.ToString();
            String idRoom=Room.Text.ToString();
            City city = new City(grad, postalCode);
            if(drzava=="Srbija")
            {
                Country country = srbija;
            }
            if (drzava == "Bosna")
            {
                Country country = bosna;
            }
            if (drzava == "Austrija")
            {
                Country country = austrija;
            }
            
            Doctor noviDoktor = new Doctor(name, surname, dateOfBirth, phoneNumber, email, id, true, username, password, city,specialization,licenseId,"null",idRoom);
            if(Name.Text=="" || Surname.Text=="" ||   PostalCode.Text==""|| PhoneNumber.Text=="" || !IsValidEmail(email) || UserName.Text=="" || Password.Password=="" || Id.Text.Length!=13  )
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
