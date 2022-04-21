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
    /// Interaction logic for MedicalCard.xaml
    /// </summary>
    public partial class MedicalCard : Window
    {
        public MedicalCard()
        {
            InitializeComponent();
            IdPatient.Text=LekarPocetna.ma.Patient.Id.ToString();
            Name.Text=LekarPocetna.ma.Patient.Name.ToString();
            Surname.Text=LekarPocetna.ma.Patient.Surname.ToString();
            Birth.Text=LekarPocetna.ma.Patient.DateOfBirth.ToString();
            IdPatient.IsReadOnly=true;
            Name.IsReadOnly = true;
            Surname.IsReadOnly = true;
            Birth.IsReadOnly = true;
         
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MedicalReport mr=new MedicalReport();
            mr.Show();
            
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Recipe r=new Recipe();
            r.Show();
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           LekarPocetna lp=new LekarPocetna();
            lp.Show();
            this.Close();
        }
    }
}
