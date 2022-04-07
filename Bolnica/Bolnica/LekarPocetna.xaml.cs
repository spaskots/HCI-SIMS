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
        AppointmentController appointmentController=new AppointmentController();
        public LekarPocetna()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment ca=new CreateAppointment();
            ca.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<MedicalAppointment> ma = appointmentController.getAllAppointment();
            foreach (MedicalAppointment m in ma)
            {
                
                MedicalAppointmentView.Items.Add(m);
                



            }
        }
        private void delete_Click(object sender,RoutedEventArgs e)
        {
            MedicalAppointment ma=MedicalAppointmentView.SelectedItem as MedicalAppointment;
            MessageBox.Show(ma.Id);
        }
    }
}
