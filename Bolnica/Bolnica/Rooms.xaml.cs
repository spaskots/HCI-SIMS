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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        private string _message;
        public Rooms()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRoomPage director = new AddRoomPage();
            director.Show();
            this.Close();
        }
        RoomController _controller = new RoomController();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Room> sobe = _controller.getAllRooms();
            foreach (Room soba in sobe)
            {
                RoomView.Items.Add(soba);
            }
        }
        private void deleteRoom(object sender, RoutedEventArgs e)
        {
            Room room = RoomView.SelectedItem as Room;
            _controller.Delete(room);

        }

        private void editRoom(object sender, RoutedEventArgs e)
        {
            Room room = RoomView.SelectedItem as Room;
            IdEdit.Text = room.Id.ToString();
            NameEdit.Text = room.Name.ToString();
            typeRoomEdit.SelectedItem = room.RoomType.ToString();

        }
        RoomRepository _repository = new RoomRepository();
        private void saveChanges(object sender, RoutedEventArgs e)
        {
            String id = IdEdit.Text;
            try
            {
                Int16 i2 = Int16.Parse(id);
                Room roomProvera = _repository.FindById(id);
                if (roomProvera == null) { return; } //Znaci da menjamo neku sa ID-jem sto ne postoji, a to nije moguce.
            }
            catch
            {
                return;
            }

            String name = NameEdit.Text;

            if (name.Length > 3) { return; }

            RoomType type;
            Enum.TryParse(typeRoomEdit.Text.ToString(), out type);
            Room room = new Room(id, name, type);
            _controller.Update(room);
        }
    }

}
