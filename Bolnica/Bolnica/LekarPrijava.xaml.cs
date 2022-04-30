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
using Bolnica.Controller;
using Bolnica.Model;


namespace Bolnica
{
    /// <summary>
    /// Interaction logic for LekarPrijava.xaml
    /// </summary>
    public partial class LekarPrijava : Window
    {
        public static string SetValueForUsername = "";

        UserController controller = new UserController();
       
        public LekarPrijava()
        {
            InitializeComponent();
            Password.PasswordChar= '*';
            Username.Focus();
            
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
            string username=Username.Text.ToString();
            SetValueForUsername = username;
            string password=Password.Password.ToString();
            RegisteredUser ru = new RegisteredUser(username, password);
            Boolean uspesnaPrijava=controller.validate(ru);
            if(uspesnaPrijava==false)
            {
                Validate.Content = "Wrong username/password!";
                Username.Text = "";
                Password.Password = "";
            }
            else
            {
                LekarPocetna lp=new LekarPocetna();
                Validate.Content = "";
                this.Close();
                lp.Show();
            }

        }

       

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender,e);
            }
        }
        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        


    }
}
