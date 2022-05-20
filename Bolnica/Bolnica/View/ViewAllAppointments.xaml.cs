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

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for ViewAllAppointments.xaml
    /// </summary>
    public partial class ViewAllAppointments : Window
    {
        AppointmentController appointmentController = new AppointmentController();
        public static MedicalAppointment appoint = null;

        public ViewAllAppointments()
        {
            InitializeComponent();
            List<MedicalAppointment> appointments = appointmentController.GetAllAppointments();

            foreach (MedicalAppointment appointment in appointments)
            {
                MedicalAppointmentView.Items.Add(appointment);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment appointment = (MedicalAppointment)MedicalAppointmentView.SelectedItem as MedicalAppointment;

            if (MessageBox.Show("Are you sure you want to delete the appointment?", "Delete appointment", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                appointmentController.delete(appointment);


                ViewAllAppointments vap = new ViewAllAppointments();
                vap.Show();
                this.Close();
            }
        }
        private void change_Click(object sender, RoutedEventArgs e)
        {
            appoint = (MedicalAppointment)MedicalAppointmentView.SelectedItem as MedicalAppointment;
            EditAppointmentSecretary ca = new EditAppointmentSecretary();
            ca.Show();
            this.Close();
        }

        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Create_Button(object sender, RoutedEventArgs e)
        {
            PriorityAppointment prio = new PriorityAppointment();
            prio.Show();
            this.Close();
        }
    }
}
