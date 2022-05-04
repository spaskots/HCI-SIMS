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
    /// Interaction logic for SingleRoomPage.xaml
    /// </summary>
    public partial class SingleRoomPage : Page
    {
        String sobaIdRenovation; 
        public SingleRoomPage(Room room)
        {
            InitializeComponent();
            sobaIdRenovation = room.Id;

            IdEdit.Text = room.Id.ToString();
            NameEdit.Text = room.Name.ToString();
            FloorEdit.Text = room.Floor.ToString();
            DescriptionEdit.Text = room.Description.ToString();
            typeRoomEdit.SelectedItem = room.RoomType.ToString();
        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            SingleRoomPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("PrikazSoba");
        }
        RoomRepository _repository = new RoomRepository();
        RoomController _controller = new RoomController();

        private void submitEditRoom(object sender, RoutedEventArgs e)
        {
            String id = IdEdit.Text;
            try
            {
                Int16 i2 = Int16.Parse(id);
                Room roomProvera = _repository.FindById(id);
                if (roomProvera == null) { MessageBox.Show("Room With This Id Doesn't Exists!"); return; } //Znaci da menjamo neku sa ID-jem sto ne postoji, a to nije moguce.    
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
            SingleRoomPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("PrikazSoba");
        }
        private void submitDeleteRoom(object sender, RoutedEventArgs e)
        {
            String id = IdEdit.Text;
            Room rDelete = _repository.FindById(id);
            if (rDelete != null) { _controller.Delete(rDelete); }
            SingleRoomPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("PrikazSoba");
           // this.Close();
            if (rDelete == null) { MessageBox.Show("Don't Change The Id,  Please Try Again!"); }
            else { MessageBox.Show("Room Successfully Deleteted!"); }
        }

        private void renovation(object sender, MouseButtonEventArgs e)
        {
            SingleRoomPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new RenovationPage(sobaIdRenovation);
        }
    }
}
