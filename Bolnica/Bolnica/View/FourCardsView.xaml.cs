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
    /// Interaction logic for FourCardsView.xaml
    /// </summary>
    public partial class FourCardsView : Page
    {
        Int64 skrol;
        Int64 korak = 4;
        Int64 temp;
        RoomController _controller = new RoomController();
        RoomRepository _repository = new RoomRepository();
        public FourCardsView(int oznaka)
        {
            InitializeComponent();
            skrol = 0;
            temp = skrol * korak;
            if(oznaka == 0) { 
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
                            Type1.Text = room.RoomType.ToString(); Id1.Text = room.Id; AdditionInfo1.Text = room.Description;
                        }
                        if (x == 1)
                        {
                            if (room == null) { Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                            else
                            {
                                Type2.Text = room.RoomType.ToString(); Id2.Text = room.Id; AdditionInfo2.Text = room.Description;
                            }
                        }
                        if (x == 2)
                        {
                            if (room == null) { Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                            else
                            {
                                Type3.Text = room.RoomType.ToString(); Id3.Text = room.Id; AdditionInfo4.Text = room.Description;
                            }
                        }
                        if (x == 3)
                        {
                            if (room == null) { Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; }
                            else
                            {
                                Type4.Text = room.RoomType.ToString();  Id4.Text = room.Id;  AdditionInfo4.Text = room.Description;
                            }
                        }
                        temp++;
                    }
            }

        }
        public static void firstFourRoom(List<Room> rooms, Int64 temp, Int64 skrol,Int64 korak)
        {
            
        }
    }
}
