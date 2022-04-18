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
        public Rooms()
        {
            InitializeComponent();
            List<Room> sobe = _controller.getAllRooms();
            foreach (Room soba in sobe)
            {
                RoomView.Items.Add(soba);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRoomPage director = new AddRoomPage();
            director.Show();
            this.Close();
        }
        RoomController _controller = new RoomController();
        private void deleteRoom(object sender, RoutedEventArgs e)
        {
            Room room = RoomView.SelectedItem as Room;
            _controller.Delete(room);
            Rooms soba = new Rooms();
            this.Close();
            soba.Show();
        }

        private void editRoom(object sender, RoutedEventArgs e)
        {
            Room room = RoomView.SelectedItem as Room;
            IdEdit.Text = room.Id.ToString();
            NameEdit.Text = room.Name.ToString();
            FloorEdit.Text = room.Floor.ToString();
            DescriptionEdit.Text = room.Description.ToString();
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
                MessageBox.Show("Room With This Id Doesn't Exists!");
            }
            catch
            {
                return;
            }

            String name = NameEdit.Text;

            if (name.Length > 3) { MessageBox.Show("Name should have less than three characters!"); return; }

            RoomType type;
            Enum.TryParse(typeRoomEdit.Text.ToString(), out type);
            String description = DescriptionEdit.Text;
            String floor = FloorEdit.Text;
            try
            {
                Int16 i2 = Int16.Parse(id);
            }
            catch
            {
                MessageBox.Show("Floor Must Be Number!");
                return;
            }
            Room room = new Room(id, name, floor, description, type);
            _controller.Update(room);
            MessageBox.Show("Success!");
        }
    }

}
