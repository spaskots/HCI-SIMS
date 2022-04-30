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
    /// Interaction logic for AddNewRoom.xaml
    /// </summary>
    public partial class AddNewRoom : Page
    {
        public AddNewRoom()
        {
            InitializeComponent();
            this.DataContext = this;
            Int16 minId = 1;
            Int16 temp = 1;
            ID = "1";
            List<Room> sobe = _controller.getAllRooms();
            foreach (Room soba in sobe)
            {
                if (soba == null) { return; }
                temp = Int16.Parse(soba.Id);
                if (temp > minId) { minId = temp; }
            }
            minId += 1;

            ID = minId.ToString();
        }
        RoomController _controller = new RoomController();
        RoomRepository _repository = new RoomRepository();

        public object ID { get; set; }

        private void addRoomSubmit(object sender, RoutedEventArgs e)
        {
            String id = idRoom.Text.ToString();
            try
            {
                Int16 i2 = Int16.Parse(id);   // Error
                Room roomProvera = _repository.FindById(id);
                if (roomProvera != null) { MessageBox.Show("ID already exists!"); return; }
            }
            catch
            {
                MessageBox.Show("Invalid ID!");
                return;
            }
            String name = nameRoom.Text.ToString();

            if (name.Length > 3) { MessageBox.Show("Name should have less than three characters!"); return; }

            String troom = typeRoom.Text.ToString();
            RoomType roomType;
            if (troom == "Operation Room") { roomType = RoomType.OperationRoom; }
            else if (troom == "Cancer Room") { roomType = RoomType.CancerRoom; }
            else if (troom == "Rest Room") { roomType = RoomType.RestRoom; }
            else { roomType = RoomType.CovidRoom; }
            String description = Description.Text.ToString();
            String floor = Floor.Text.ToString();
            try
            {
                Int16 i2 = Int16.Parse(floor);   // Error
                if (floor == null) { return; }
            }
            catch
            {
                MessageBox.Show("Floor Must Be Number!");
                return;
            }
            Room room = new Room(id, name, floor, description, roomType);
            _controller.Create(room);
            MessageBox.Show("Successfully added room!");
           // RoomPage director = new RoomPage();
            //director.Show();
            AddNewRoomContent.Visibility = Visibility.Hidden;
           
        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
