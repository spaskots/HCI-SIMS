using Bolnica.Controller;
using Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for PriorityAppointment.xaml
    /// </summary>
    public partial class PriorityAppointment : Window
    {
        private LekarController lekarController = new LekarController();
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        public PriorityAppointment()
        {
            InitializeComponent();
            List<Doctor> doctors = lekarController.GetAll();
            List<Patient> patients = patientController.getAllPatients();
            doctorCombo.ItemsSource = doctors;
            patientCombo.ItemsSource = patients;
            appointmentTypeCombo.Items.Add("Operation");
            appointmentTypeCombo.Items.Add("Examination");
        }

        private void StartCalendarOpenedRestrictions(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            picker.DisplayDateStart = DateTime.Now;
            if (!(endDate.SelectedDate is null))
            {
                picker.DisplayDateEnd = (DateTime)endDate.SelectedDate;
            }
        }

        private void DatesAreSelected(object sender, SelectionChangedEventArgs e)
        {
            if (startDate.SelectedDate is null || endDate.SelectedDate is null)
            {
                return;
            }
            showAvailableAppointmentsButton.IsEnabled = true;
            ToolTip tooltip = new ToolTip { };
            showAvailableAppointmentsButton.ToolTip = tooltip;
            tooltip.Visibility = Visibility.Hidden;
        }

        private void TimeIsSelected(object sender, SelectionChangedEventArgs e)
        {
            Submit.IsEnabled = true;
            ToolTip tooltip = new ToolTip { };
            Submit.ToolTip = tooltip;
            tooltip.Visibility = Visibility.Hidden;
        }
        private void EndCalendarOpenedRestrictions(object sender, RoutedEventArgs e)
        {
            var picker = sender as DatePicker;
            if (startDate.SelectedDate is null)
            {
                picker.DisplayDateStart = DateTime.Now;
            }
            else
            {
                picker.DisplayDateStart = (DateTime)startDate.SelectedDate;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MedicalAppointment appointment = (MedicalAppointment)availableAppointments.SelectedItem;
            Patient patient = (Patient)patientCombo.SelectedItem;
            //string patientId = (string)patientCombo.SelectedItem;


            List<int> ids = appointmentController.getAllId();
            int id;
            if (ids.Count == 0)
            {
                id = 0;
            } else
            {
                id = ids.Last() + 1;
            }
            // (int id, string patientId, string doctorId, String startTime, double duration, AppointmentType type)
            String appointmentType = (String)appointmentTypeCombo.SelectedItem as String;
            int boolType;
            if (appointmentType == "operation")
            {
                System.Diagnostics.Debug.WriteLine("Operacija");
                boolType = 1;
            } else { boolType = 0; }

            AppointmentType type;

            Enum.TryParse(appointmentType.ToString(), out type);
            MedicalAppointment ma = new MedicalAppointment(id, patient.Id, appointment.doctor.Id, appointment.StartTime, appointment.Duration, type);
            
            Room r = ma.findRoom(appointment.doctor.Room.Id);
            ma.SetRoom(r);
            appointmentController.save(ma);

            MessageBox.Show("Successfully scheduled medical appointment.");

        }

        private void showAvailableAppointments(object sender, RoutedEventArgs e)
        {
            DateTime start = (DateTime)startDate.SelectedDate;
            DateTime end = (DateTime)endDate.SelectedDate;
            Doctor doctor = (Doctor)doctorCombo.SelectedItem as Doctor;
            String appointmentType = (String)appointmentTypeCombo.SelectedItem as String;
            int duration = Convert.ToInt32(Duration.Text);
            String priority = "";

            if ((Boolean)doctorRadio.IsChecked)
            {
                priority = "doctor";
            }
            if ((Boolean)dateRadio.IsChecked)
            {
                priority = "date";
            }

            if ((end-start).Days > 7)
            {
                MessageBox.Show("Date Picker Error: Maximal range is 7 days");
            } else
            {
                List<MedicalAppointment> appointments = appointmentController.FindByPriority(priority, doctor.Id, start, end, duration, appointmentType);
                availableAppointments.ItemsSource = appointments;
            }
        }

        private static readonly Regex _regex = new Regex("[^1-9][^0-9]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }


    }
}
