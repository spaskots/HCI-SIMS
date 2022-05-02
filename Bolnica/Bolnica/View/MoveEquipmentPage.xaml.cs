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
    /// Interaction logic for MoveEquipmentPage.xaml
    /// </summary>
    public partial class MoveEquipmentPage : Page
    {
        RoomController room_controller = new RoomController();
        StaticEquipmentController staticEquipment_controller = new StaticEquipmentController();
        StaticEquipmentRepository staticEquipment_repository = new StaticEquipmentRepository();
        RoomRepository room_repository = new RoomRepository();
        StaticEquipment staticMoveLater = new StaticEquipment();
        public MoveEquipmentPage(int staticEquipmentId)
        {
            InitializeComponent();
            OnDate.DisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            StaticEquipment se = staticEquipment_repository.FindById(staticEquipmentId);

            staticMoveLater.Id = staticEquipmentId;
            staticMoveLater.Quantity = se.Quantity;
            staticMoveLater.roomId = se.roomId;

            EquipmentMove.Text = se.Id + "  " + se.Name + "  " + "Available Quantity: " + se.Quantity;
            Room fromRoom = room_repository.FindById(se.roomId);
            FromRoomMove.Text = fromRoom.Id + "  " + fromRoom.Name + "  " + fromRoom.RoomType;
            List<Room> rooms = room_controller.getAllRooms();
            foreach (Room room in rooms)
            {
                ToRoomMove.Items.Add(room.Id + "  " + room.Name + "  " + room.RoomType);
            }

        }

        private void submitMoveEquipment(object sender, MouseButtonEventArgs e)
        {
            String quantityMoveString = QuantityMove.Text.ToString();
            int quantityMove = -1;
            try
            {
                quantityMove = Int32.Parse(quantityMoveString);
            }
            catch (Exception easda) { MessageBox.Show("Pogresan format, probaj opet!"); return; }
            if (quantityMove > staticMoveLater.Quantity) { MessageBox.Show("Enter Valid Quantity!"); return; }
            DateTime? selectedDate = OnDate.SelectedDate;
            DateTime dtValue;
            if (selectedDate.HasValue)
            {
                //string formatted = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                dtValue = (DateTime)selectedDate;
            }
            else { MessageBox.Show("Izaberite datum Premestanja!"); return; }

            int selectedIndex = -1;

            selectedIndex = ToRoomMove.SelectedIndex;
            List<Room> rooms = room_controller.getAllRooms();
            Room soba = rooms.ElementAt(selectedIndex);
            if (soba.Id == staticMoveLater.roomId) { MessageBox.Show("Ne moze u istu sobu, Izaberi Drugu!"); return; }

            String description = DescriptionMove.Text.ToString();

            MoveExecution me = new MoveExecution(staticMoveLater.Id, dtValue, soba.Id, quantityMove, description);
            staticEquipment_controller.MoveExecutionSubmit(me);
            MessageBox.Show("Uspesno zabelezeno!");
        }
    
        private void back(object sender, MouseButtonEventArgs e)
        {
            MoveEquipmentPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("StaticEquipmentSelected");
        }
    }
}

