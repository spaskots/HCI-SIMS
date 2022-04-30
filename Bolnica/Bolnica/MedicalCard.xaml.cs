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
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MedicalCard.xaml
    /// </summary>
    public partial class MedicalCard : Window
    {
        MedicalCardController medicalCardController=new MedicalCardController();
        public static MedCard medicalCard = null;
       
        public MedicalCard()
        {
            InitializeComponent();
            String idPatient = LekarPocetna.ma.Patient.Id;
            medicalCard = medicalCardController.getOneByPatientId(idPatient);
            IdPatient.Text = medicalCard.patient.Id.ToString();
            IdMedicalCard.Text = medicalCard.Id.ToString();
            Name.Text=medicalCard.patient.Name.ToString();
            Surname.Text=medicalCard.patient.Surname.ToString();
            Birth.Text=medicalCard.patient.DateOfBirth.ToString();
            IdPatient.IsReadOnly=true;
            Name.IsReadOnly = true;
            Surname.IsReadOnly = true;
            Birth.IsReadOnly = true;
            IdMedicalCard.IsReadOnly = true;
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

        private void IdMedicalCard_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
