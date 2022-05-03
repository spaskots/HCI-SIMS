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
        String eventNaClick = "";
        RoomController room_controller = new RoomController();
        RoomRepository room_repository = new RoomRepository();
        StaticEquipmentController staticEquipment_controller = new StaticEquipmentController();
        StaticEquipmentRepository staticEquipment_repository = new StaticEquipmentRepository();
        DynamicEquipmentController dynamicEquipment_controller = new DynamicEquipmentController();
        public FourCardsView(String oznaka)
        {
            InitializeComponent();

            if (oznaka == "DynamicEquipmentSelected")
            {
                dynamicEquipmentIspis();
            }
            skrol = 0;
            temp = skrol * korak;
            List<Room> rooms = room_controller.getAllRooms();
            List<StaticEquipment> staticEquipments = staticEquipment_controller.getAllStaticEquipment();
            if (oznaka == "PrikazSoba")
            {
                AddNewRoomButton.Visibility = Visibility.Visible;
                
                eventNaClick = "Room";
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
                            Type4.Text = room.RoomType.ToString(); Id4.Text = room.Id; AdditionInfo4.Text = room.Description;
                        }
                    }
                    temp++;
                }
            }
            if (oznaka == "StaticEquipmentSelected")
            {
                NewSupplyRequestButton.Visibility = Visibility.Visible;

                eventNaClick = "StaticEquipmentInRoom";
                Type1.Text = "All Equipment";
                Id1.Text = "-";
                foreach (StaticEquipment se in staticEquipments) {
                    Room r = room_repository.FindById(se.roomId);
                    AdditionInfo1.Text += " *" + se.Name + " " + r.Name + " " + se.Quantity + "* ";
                }
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
                        if (room == null) { Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                        else
                        {
                            Type2.Text = room.RoomType.ToString(); Id2.Text = room.Id;
                            foreach (StaticEquipment se in staticEquipments)
                            {
                                Room r = room_repository.FindById(se.roomId);
                                if (room.Id == se.roomId) { AdditionInfo2.Text += " *" + se.Name + " " + r.Name + " " + se.Quantity + "* "; }
                            }
                        }
                    }
                    if (x == 1)
                    {
                        if (room == null) { Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                        else
                        {
                            Type3.Text = room.RoomType.ToString(); Id3.Text = room.Id;
                            foreach (StaticEquipment se in staticEquipments)
                            {
                                Room r = room_repository.FindById(se.roomId);
                                if (room.Id == se.roomId) { AdditionInfo3.Text += " *" + se.Name + " " + r.Name + " " + se.Quantity + "* "; }
                            }
                        }
                    }
                    if (x == 2)
                    {
                        if (room == null) { Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; }
                        else
                        {
                            Type4.Text = room.RoomType.ToString(); Id4.Text = room.Id;
                            foreach (StaticEquipment se in staticEquipments)
                            {
                                Room r = room_repository.FindById(se.roomId);
                                if (room.Id == se.roomId) { AdditionInfo4.Text += " *" + se.Name + " " + r.Name + " " + se.Quantity + "* "; }
                            }
                        }
                    }

                    temp++;
                }
            }
        }
        private void addNewRoom(object sender, RoutedEventArgs e)
        {
            FourCardsViewName.Visibility = Visibility.Hidden;
            MoveEquipmentFrame.Content = new AddNewRoom();
        }
        private void Grid_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            String IdSobe = Id1.Text;
            if (IdSobe == "") { return; }

            if (eventNaClick == "Room")
            {
                Room room = room_repository.FindById(IdSobe);
                if (room == null) { return; }
                FourCardsViewName.Visibility = Visibility.Hidden;
                SingleRoomFrame.Content = new SingleRoomPage(room);
                
            }
            if (eventNaClick == "SingleStaticEquipment")
            {
                FourCardsViewName.Visibility = Visibility.Hidden;
                MoveEquipmentFrame.Content = new MoveEquipmentPage(Int32.Parse(IdSobe));
            }
            if (eventNaClick == "StaticEquipmentInRoom")
            {
                if (IdSobe == "") { return; }

                if (IdSobe == "-")
                {
                    staticEquipmentInAllRoomsFunction();
                }
                else
                {
                    staticEquipmentInRoomFunction(IdSobe);
                }
            }
        }
        private void Grid_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            String IdSobe = Id2.Text;
            if (IdSobe == "") { return; }
            if (eventNaClick == "Room")
            {
                Room room = room_repository.FindById(IdSobe);
                if (room == null) { return; }
                FourCardsViewName.Visibility = Visibility.Hidden;
                SingleRoomFrame.Content = new SingleRoomPage(room);

            }
            if (eventNaClick == "SingleStaticEquipment")
            {
                FourCardsViewName.Visibility = Visibility.Hidden;
                MoveEquipmentFrame.Content = new MoveEquipmentPage(Int32.Parse(IdSobe));
            }

            if (eventNaClick == "StaticEquipmentInRoom")
            {
                staticEquipmentInRoomFunction(IdSobe);
            }
        }
        private void Grid_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            String IdSobe = Id3.Text;
            if (IdSobe == "") { return; }

            if (eventNaClick == "Room")
            {
                Room room = room_repository.FindById(IdSobe);
                if (room == null) { return; }
                FourCardsViewName.Visibility = Visibility.Hidden;
                SingleRoomFrame.Content = new SingleRoomPage(room);

            }
            if (eventNaClick == "SingleStaticEquipment")
            {
                FourCardsViewName.Visibility = Visibility.Hidden;
                MoveEquipmentFrame.Content = new MoveEquipmentPage(Int32.Parse(IdSobe));
            }
            if (eventNaClick == "StaticEquipmentInRoom")
            {
                staticEquipmentInRoomFunction(IdSobe);
            }
        }
        private void Grid_MouseDown4(object sender, MouseButtonEventArgs e)
        {
            String IdSobe = Id4.Text;
            if (IdSobe == "") { return; }
            if (eventNaClick == "Room")
            {
                Room room = room_repository.FindById(IdSobe);
                if (room == null) { return; }
                FourCardsViewName.Visibility = Visibility.Hidden;
                SingleRoomFrame.Content = new SingleRoomPage(room);

            }
            if (eventNaClick == "SingleStaticEquipment")
            {
                FourCardsViewName.Visibility = Visibility.Hidden;
                MoveEquipmentFrame.Content = new MoveEquipmentPage(Int32.Parse(IdSobe));
            }
            if (eventNaClick == "StaticEquipmentInRoom")
            {
                staticEquipmentInRoomFunction(IdSobe);
            }
        }
        public void staticEquipmentInAllRoomsFunction()
        {
            NewSupplyRequestButton.Visibility = Visibility.Hidden;
            CurrentRoomNameEq.Visibility = Visibility.Visible;
            CurrentRoomIdEq.Visibility = Visibility.Visible;

            CurrentRoomNameEq.Text = "All Equipment";
            CurrentRoomIdEq.Text = "-";

            eventNaClick = "SingleStaticEquipment";
            skrol = 0;
            temp = skrol * korak;
            List<StaticEquipment> equipments = staticEquipment_controller.getAllStaticEquipment();
            for (Int64 x = 0; x < 4; x++)
            {
                StaticEquipment equipment = new StaticEquipment();
                try
                {
                    StaticEquipment oprema = equipments.ElementAt((int)temp);
                    equipment.Id = oprema.Id; equipment.Name = oprema.Name; equipment.Quantity = oprema.Quantity; equipment.roomId = oprema.roomId;
                }
                catch (Exception nekaGreska)
                {
                    equipment = null;
                }
                if (equipment == null && x == 0) { return; }
                if (x == 0)
                {
                    Type1.Text = equipment.Name.ToString(); Id1.Text = equipment.Id.ToString(); AdditionInfo1.Text = "Available Quantity: " + equipment.Quantity.ToString();
                }
                if (x == 1)
                {
                    if (equipment == null) { Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                    else
                    {
                        Type2.Text = equipment.Name.ToString(); Id2.Text = equipment.Id.ToString(); AdditionInfo2.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                }
                if (x == 2)
                {
                    if (equipment == null) { Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return; }
                    else
                    {
                        Type3.Text = equipment.Name.ToString(); Id3.Text = equipment.Id.ToString(); AdditionInfo3.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                }
                if (x == 3)
                {
                    if (equipment == null) { Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; }
                    else
                    {
                        Type4.Text = equipment.Name.ToString(); Id4.Text = equipment.Id.ToString(); AdditionInfo4.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                }
                temp++;
            }
        }
        public void staticEquipmentInRoomFunction(String IdSobe)
        {
            NewSupplyRequestButton.Visibility = Visibility.Hidden;

            CurrentRoomNameEq.Visibility = Visibility.Visible;
            CurrentRoomIdEq.Visibility = Visibility.Visible;
            Room RoomNameId = room_repository.FindById(IdSobe);
            CurrentRoomNameEq.Text = RoomNameId.RoomType + " " +RoomNameId.Name;
            CurrentRoomIdEq.Text = RoomNameId.Id;


            eventNaClick = "SingleStaticEquipment";
            skrol = 0;
            List<StaticEquipment> equipments = staticEquipment_controller.getAllStaticEquipment();
            temp = 0;
            Boolean preskaci = true;
            for (Int64 x = 0; x < equipments.Count; x++) // idi do kraja liste
            {
                StaticEquipment equipment = new StaticEquipment();
                StaticEquipment oprema = equipments.ElementAt((int)x);
                if (oprema.roomId == IdSobe)
                {
                    equipment.Id = oprema.Id; equipment.Name = oprema.Name; equipment.Quantity = oprema.Quantity; equipment.roomId = oprema.roomId;
                    if (temp == 0)
                    {
                        Type1.Text = equipment.Name.ToString(); Id1.Text = equipment.Id.ToString(); AdditionInfo1.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 1)
                    {
                        Type2.Text = equipment.Name.ToString(); Id2.Text = equipment.Id.ToString(); AdditionInfo2.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 2)
                    {
                        Type3.Text = equipment.Name.ToString(); Id3.Text = equipment.Id.ToString(); AdditionInfo3.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 3)
                    {
                        Type4.Text = equipment.Name.ToString(); Id4.Text = equipment.Id.ToString(); AdditionInfo4.Text = "Available Quantity: " + equipment.Quantity.ToString();
                        return;
                    }
                    temp++;
                }
            }
            if (temp == 0)
            {
                Type1.Text = ""; Id1.Text = ""; AdditionInfo1.Text = ""; Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 1)
            {
                Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 2)
            {
                Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 3)
            {
                Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
        }
        
        public void dynamicEquipmentIspis()
        {
            skrol = 0;
            List<DynamicEquipment> equipments = dynamicEquipment_controller.GetAllDynamicEquipments();
            temp = 0;
            for (Int64 x = 0; x < equipments.Count; x++) // idi do kraja liste
            {
                DynamicEquipment equipment = new DynamicEquipment();
                DynamicEquipment oprema = equipments.ElementAt((int)x);
                {
                    equipment.Id = oprema.Id; equipment.Name = oprema.Name; equipment.Quantity = oprema.Quantity;
                    if (temp == 0)
                    {
                        Type1.Text = equipment.Name.ToString(); Id1.Text = equipment.Id.ToString(); AdditionInfo1.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 1)
                    {
                        Type2.Text = equipment.Name.ToString(); Id2.Text = equipment.Id.ToString(); AdditionInfo2.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 2)
                    {
                        Type3.Text = equipment.Name.ToString(); Id3.Text = equipment.Id.ToString(); AdditionInfo3.Text = "Available Quantity: " + equipment.Quantity.ToString();
                    }
                    if (temp == 3)
                    {
                        Type4.Text = equipment.Name.ToString(); Id4.Text = equipment.Id.ToString(); AdditionInfo4.Text = "Available Quantity: " + equipment.Quantity.ToString();
                        return;
                    }
                    temp++;
                }
            }
            if (temp == 0)
            {
                Type1.Text = ""; Id1.Text = ""; AdditionInfo1.Text = ""; Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 1)
            {
                Type2.Text = ""; Id2.Text = ""; AdditionInfo2.Text = ""; Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 2)
            {
                Type3.Text = ""; Id3.Text = ""; AdditionInfo3.Text = ""; Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
            if (temp == 3)
            {
                Type4.Text = ""; Id4.Text = ""; AdditionInfo4.Text = ""; return;
            }
        }
    }
}
