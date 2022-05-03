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
    /// Interaction logic for LekarPocetna.xaml
    /// </summary>
    public partial class LekarPocetna : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        LekarController lekarController = new LekarController();
        RoomController roomController = new RoomController();
        PatientController patientController = new PatientController();
       public static MedicalAppointment ma = null;
        public LekarPocetna()
        {
            InitializeComponent();
            String username = LekarPrijava.SetValueForUsername;
            Doctor doctor = lekarController.GetOneByUsername(username);
            List<MedicalAppointment> ma = appointmentController.GetAllAppointmentsByDoctorId(doctor.Id);
            foreach (MedicalAppointment m in ma)
            {

                MedicalAppointmentView.Items.Add(m);
            }
            
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
               


                LekarPrijava lp = new LekarPrijava();
                lp.Show();
                this.Close();
            }
            else
            {


            }
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        private void delete_Click(object sender,RoutedEventArgs e)
        {
             ma=MedicalAppointmentView.SelectedItem as MedicalAppointment;
           
            if (MessageBox.Show("Are you sure you want to delete the appointment?", "Delete appointment", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                appointmentController.delete(ma);


                LekarPocetna lp = new LekarPocetna();
                lp.Show();
                this.Close();
            }
            else
            {
                
                
            }
            
        }
        private void change_Click(object sender,RoutedEventArgs e)
        {
            ma = MedicalAppointmentView.SelectedItem as MedicalAppointment;
           ChangeAppointment ca=new ChangeAppointment  ();
            ca.Show();
            this.Close();
            
        }
        private void MedicalCard_Click(object sender, RoutedEventArgs e)
        {
            ma = MedicalAppointmentView.SelectedItem as MedicalAppointment;
            MedicalCard mc=new MedicalCard();
            mc.Show();
            this.Close();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

        }

        private void Make_an_appointment_Click(object sender, RoutedEventArgs e)
        {
            
            CreateAppointment ca=new CreateAppointment();
            ca.Show();
            this.Close();
        }

        private void MedicalAppointmentView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
