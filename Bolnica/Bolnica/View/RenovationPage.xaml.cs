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
        String clickOnButton;
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

            clickOnButton = "Renovation";
            List<Room> rooms = room_controller.getAllRooms();
            foreach (Room room in rooms)
            {
                MergeWithRoomName.Items.Add(room.Id + "  " + room.Name + "  " + room.RoomType);
            }
        }

        private void startDateName_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = startDateName.SelectedDate;
            DateTime startDate;
            startDate = (DateTime)selectedDate;
            endDateName.DisplayDateStart = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            endDateName.SelectedDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            List<DateTime> sheduledDates = room_repository.takenRoomDates(idSobe);
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
            if (clickOnButton == "Renovation")
            {
                RenovationExecution re = new RenovationExecution(startDate, endDate, idSobe, description);

                room_controller.renovation(re);
                MessageBox.Show("Successfully Sheduled Renovation!");
            }
            else if (clickOnButton == "AdvancedRenovation")
            {
                if (Convert.ToBoolean(rb1.IsChecked))
                {
                    AdvancedRenovationExecution are = new AdvancedRenovationExecution(startDate, endDate, idSobe, description); //Split
                    room_repository.advancedRenovationSave(are);
                    MessageBox.Show("Successfully Sheduled Advanced SPLIT Renovation!");
                }
                else if (Convert.ToBoolean(rb2.IsChecked))//Merge
                {
                    int selectedIndex = MergeWithRoomName.SelectedIndex;
                    List<Room> rooms = room_controller.getAllRooms();
                    Room mergeWithRoom = rooms.ElementAt(selectedIndex);
                    if (mergeWithRoom.Id == idSobe)
                    {
                        MessageBox.Show("Please Choose Other Room!"); return;
                    }
                    AdvancedRenovationExecution are = new AdvancedRenovationExecution(startDate, endDate, idSobe, mergeWithRoom.Id, description); //Split
                    room_repository.advancedRenovationSave(are);
                    MessageBox.Show("Successfully Sheduled Advanced Merge Renovation!");

                }
               else MessageBox.Show("You Have To Choose Between Merge and Split Option In This Mode!"); return;
            }
        }
        private void back(object sender, MouseButtonEventArgs e)
        {
            if (clickOnButton == "Renovation")
            {
                RenovationPageName.Visibility = Visibility.Hidden;
                PagesFrame.Content = new SingleRoomPage(room_repository.FindById(idSobe));
            }
            else if(clickOnButton == "AdvancedRenovation")
            {
                clickOnButton = "Renovation";
                MergeWithRoomLabelName.Visibility = Visibility.Hidden;
                MergeWithRoomName.Visibility = Visibility.Hidden;
                rb1.Visibility = Visibility.Hidden;
                rb2.Visibility = Visibility.Hidden;
                AdvancedRenovationButton.Visibility = Visibility.Visible;
                HeaderTittleName.Content = "Renovation";
               // LeftHeaderIconName.Source = new BitmapImage(new Uri(@"..\icons8-back-96.png"));
            }
        }

        private void HandleRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(rb1.IsChecked)) {
                MergeWithRoomLabelName.Visibility = Visibility.Visible;
                MergeWithRoomName.IsEnabled = false;
                MergeWithRoomName.Visibility = Visibility.Visible;

            }
            if (Convert.ToBoolean(rb2.IsChecked)) {
                //Merge
                MergeWithRoomLabelName.Visibility = Visibility.Visible;
                MergeWithRoomName.IsEnabled = true;
                MergeWithRoomName.Visibility = Visibility.Visible;
            }
        }
        private void AdvancedRenovationButtonActivation(object sender, RoutedEventArgs e)
        {
            clickOnButton = "AdvancedRenovation";
            MergeWithRoomLabelName.Visibility = Visibility.Visible;
            MergeWithRoomName.Visibility = Visibility.Visible;
            rb1.Visibility = Visibility.Visible;
            rb2.Visibility = Visibility.Visible;
            AdvancedRenovationButton.Visibility = Visibility.Hidden;
            HeaderTittleName.Content = "Advanced Renovation";
            //LeftHeaderIconName.Source = new BitmapImage(new Uri(@"..\View\icons8-x-50.png"));
        }
       
    }
}
