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
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for AddRoomPage.xaml
    /// </summary>
    public partial class AddRoomPage : Window
    {
        public AddRoomPage()
        {
            InitializeComponent();
        }
        RoomController _controller = new RoomController();
        RoomRepository _repository = new RoomRepository();
        private void addRoomSubmit(object sender, RoutedEventArgs e)
        {
            String id = idRoom.Text.ToString();
            try
            {
                Int16 i2 = Int16.Parse(id);   // Error
                Room roomProvera = _repository.FindById(id);
                if (roomProvera != null) { return; }
            }
            catch
            {
                return;
            }
            String name = nameRoom.Text.ToString();

            if (name.Length < 3) { return; }

            String troom = typeRoom.Text.ToString();
            RoomType roomType;
            if (troom == "Operation Room") { roomType = RoomType.OperationRoom; }
            else if (troom == "Cancer Room") { roomType = RoomType.CancerRoom; }
            else if (troom == "Rest Room") { roomType = RoomType.RestRoom; }
            else { roomType = RoomType.CovidRoom; }
            Room room = new Room(id, name, roomType);
            _controller.Create(room);
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            Rooms director = new Rooms();
            director.Show();
            this.Close();
        }
    }
}
