using Bolnica.Controller;
using Bolnica.Model;
using Bolnica.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for RenovationPage.xaml
    /// </summary>
    public partial class RenovationPage : Page
    {
        RoomRepository room_repository = new RoomRepository();
        RoomController room_controller = new RoomController();
        String idSobe;
        public RenovationPage(String roomId)
        {
            InitializeComponent();
            Room soba = room_repository.FindById(roomId);
            RoomRenovationName.Text = soba.Id + " " + soba.Name + " " + soba.RoomType.ToString();
            idSobe = soba.Id;

            startDateName.DisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            List<DateTime> sheduledDates = room_repository.takenRoomDates(roomId); // za koju sobu mi trebaju zauzeti datumi
            for (int x = 0; x < sheduledDates.Count; x++)
            {
                DateTime startDate = sheduledDates.ElementAt(x);
                x++;
                DateTime endDate = sheduledDates.ElementAt(x);
                startDateName.BlackoutDates.Add(new CalendarDateRange(new DateTime(startDate.Year, startDate.Month, startDate.Day), new DateTime(endDate.Year, endDate.Month, endDate.Day)));
            }
        }

        private void startDateName_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = startDateName.SelectedDate;
            DateTime startDate;
            startDate = (DateTime)selectedDate;
            endDateName.DisplayDateStart = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            endDateName.SelectedDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            List<DateTime> sheduledDates = room_repository.takenRoomDates("1");
            DateTime gornjaGranica = new DateTime(2030, 12, 31); // 10 dina unapred
            for (int x = 0; x < sheduledDates.Count; x++)
            {
                if (x % 2 == 0) // startDate
                {
                    int result = DateTime.Compare(startDate, sheduledDates.ElementAt(x));
                    if (result < 0) //Prosla Prva provera
                    {
                        result = DateTime.Compare(sheduledDates.ElementAt(x), gornjaGranica);
                        if (result < 0) // Prosao drugu proveru
                        {
                            gornjaGranica = sheduledDates.ElementAt(x); // Dobijam novu granicu
                        }
                    }
                }
            }
            endDateName.DisplayDateEnd = new DateTime(gornjaGranica.Year, gornjaGranica.Month, gornjaGranica.Day - 1);
        }

        private void submitRenovation(object sender, MouseButtonEventArgs e)
        {
            DateTime? selectedStartDate = startDateName.SelectedDate;
            DateTime startDate;
            if (selectedStartDate.HasValue)
            {
                startDate = (DateTime)selectedStartDate;
                startDate = startDate.Date.AddHours(00).AddMinutes(00).AddSeconds(00);
            }
            else { MessageBox.Show("Choose Start Date!"); return; }

            DateTime? selectedEndDate = endDateName.SelectedDate;
            DateTime endDate;
            if (selectedEndDate.HasValue)
            {
                endDate = (DateTime)selectedEndDate;
                startDate = startDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            else { MessageBox.Show("Choose End Date!"); return; }
            String description = DescriptionRenovationName.Text;
            RenovationExecution re = new RenovationExecution(startDate, endDate, idSobe, description);

            room_controller.renovation(re);
            MessageBox.Show("Successfully Sheduled Renovation!");
        }
        private void back(object sender, MouseButtonEventArgs e)
        {
            RenovationPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new SingleRoomPage(room_repository.FindById(idSobe));
        }
    }
}
