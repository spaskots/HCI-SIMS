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
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Window
    {
        Int64 skrol;
        Int64 korak = 4;
        Int64 temp;
        RoomController _controller = new RoomController();
        RoomRepository _repository = new RoomRepository();
        public RoomPage()
        {
            InitializeComponent();
            skrol = 0;
            temp = skrol * korak;
            List<Room> rooms = _controller.getAllRooms();
            for (Int64 x = 0; x < 4; x++)
            {
                Room room = new Room();
                try
                {
                    Room soba = rooms.ElementAt((int)temp);
                    room.Id = soba.Id; room.Name = soba.Name; room.Floor = soba.Floor; room.Description = soba.Description; room.RoomType = soba.RoomType;
                }
                catch (Exception nekaGreska)
                {
                    room = null;
                }
                if (room == null && x == 0) { return; }
                if (x == 0)
                {
                    RoomType1.Text = room.RoomType.ToString(); Id1.Text = room.Id; Description1.Text = room.Description;
                }
                if (x == 1)
                {
                    if (room == null) { RoomType2.Text = ""; Id2.Text = ""; Description2.Text = ""; RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else
                    {
                        RoomType2.Text = room.RoomType.ToString(); Id2.Text = room.Id; Description2.Text = room.Description;
                    }
                }
                if (x == 2)
                {
                    if (room == null) { RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else
                    {
                        RoomType3.Text = room.RoomType.ToString(); Id3.Text = room.Id; Description3.Text = room.Description;
                    }
                }
                if (x == 3)
                {
                    if (room == null) { RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; }
                    else
                    {
                        RoomType4.Text = room.RoomType.ToString(); Id4.Text = room.Id; Description4.Text = room.Description;
                    }
                }
                temp++;
            }

        }



        private void Grid_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            Room room = _repository.FindById(Id1.Text);
            if (room == null) { return; }
            SingleRoom director = new SingleRoom(room);
            director.Show();
            this.Close();
        }
        private void Grid_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            Room room = _repository.FindById(Id2.Text);
            if (room == null) { return; }
            SingleRoom director = new SingleRoom(room);
            director.Show();
            this.Close();
        }
        private void Grid_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            Room room = _repository.FindById(Id3.Text);
            if (room == null) { return; }
            SingleRoom director = new SingleRoom(room);
            director.Show();
            this.Close();
        }
        private void Grid_MouseDown4(object sender, MouseButtonEventArgs e)
        {
            Room room = _repository.FindById(Id4.Text);
            if (room == null) { return; }
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
        private void next(object sender, RoutedEventArgs e)
        {
            skrol++;
            temp = skrol * korak;
            List<Room> rooms = _controller.getAllRooms();

            for (Int64 x = 0; x < 4; x++)
            {
                Room room = new Room();
                try
                {
                    Room soba = rooms.ElementAt((int)temp);
                    room.Id = soba.Id; room.Name = soba.Name; room.Floor = soba.Floor; room.Description = soba.Description; room.RoomType = soba.RoomType;

                }
                catch (Exception nekaGreska)
                {
                    room = null;
                }
                //Room room = rooms.ElementAt((int)temp);

               
                if (room == null && x ==0) { skrol--; return; }
                if (x == 0) { 
                    RoomType1.Text = room.RoomType.ToString();
                    Id1.Text = room.Id;
                    Description1.Text = room.Description;
                }
                if (x == 1)
                {
                    if (room == null) { RoomType2.Text = ""; Id2.Text = ""; Description2.Text = ""; RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else
                    {
                        RoomType2.Text = room.RoomType.ToString();
                        Id2.Text = room.Id;
                        Description2.Text = room.Description;
                    }
                }
                if (x == 2)
                {
                    if (room == null) { RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else
                    {
                        RoomType3.Text = room.RoomType.ToString();
                        Id3.Text = room.Id;
                        Description3.Text = room.Description;
                    }
                }
                if (x == 3)
                {
                    if (room == null) { RoomType4.Text = ""; Id4.Text = ""; Description4.Text = "";}
                    else
                    {
                        RoomType4.Text = room.RoomType.ToString();
                        Id4.Text = room.Id;
                        Description4.Text = room.Description;
                    }
                }
                temp++;
            }
        }

 
        private void previous(object sender, RoutedEventArgs e)
        {
            skrol--;
            temp = skrol * korak;
            List<Room> rooms = _controller.getAllRooms();
            for (Int64 x = 0; x < 4; x++)
            {
                Room room = new Room();
                try
                {
                    Room soba = rooms.ElementAt((int)temp);
                    room.Id = soba.Id; room.Name = soba.Name; room.Floor = soba.Floor; room.Description = soba.Description; room.RoomType = soba.RoomType;

                }
                catch (Exception nekaGreska)
                {
                    room = null;
                }
                if (room == null && x == 0) { skrol++; return; }
                if (x == 0)
                {
                    RoomType1.Text = room.RoomType.ToString();
                    Id1.Text = room.Id;
                    Description1.Text = room.Description;
                }
                if (x == 1)
                {
                    if(room == null) { RoomType2.Text = ""; Id2.Text = ""; Description2.Text = ""; RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else { 
                    RoomType2.Text = room.RoomType.ToString();
                    Id2.Text = room.Id;
                    Description2.Text = room.Description;
                    }
                }
                if (x == 2)
                {
                    if (room == null) { RoomType3.Text = ""; Id3.Text = ""; Description3.Text = ""; RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; return; }
                    else { 
                    RoomType3.Text = room.RoomType.ToString();
                    Id3.Text = room.Id;
                    Description3.Text = room.Description;
                    }
                }
                if ( x == 3)
                {
                    if (room == null) { RoomType4.Text = ""; Id4.Text = ""; Description4.Text = ""; }
                    else
                    {
                        RoomType4.Text = room.RoomType.ToString();
                        Id4.Text = room.Id;
                        Description4.Text = room.Description;
                    }
                }
                temp++;
            }

        }

        private void roomPage(object sender, MouseButtonEventArgs e)
        {
            RoomPage director = new RoomPage();
            director.Show();
            this.Close();
        }
        private void equipment(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
