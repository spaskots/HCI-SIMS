using Bolnica.Controller;
using Bolnica.Model;
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
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Window
    {
        RoomController _controller = new RoomController();
        public RoomPage()
        {
            InitializeComponent();
            List<Room> sobe = _controller.getAllRooms();
            foreach (Room soba in sobe)
            {
                RoomView.Items.Add(soba);
            }
        }

 

        private void RoomView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = RoomView.SelectedItem as Room;
            SingleRoom director = new SingleRoom(room);
            director.Show();
            this.Close();
        }

        private void addNewRoom(object sender, RoutedEventArgs e)
        {
            AddRoomPage director = new AddRoomPage();
            director.Show();
            this.Close();
        }
    }
}
