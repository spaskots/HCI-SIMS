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
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : Window
    {
        RoomController _controller = new RoomController();
        public RoomView()
        {
            InitializeComponent();
            // this.DataContext = this;
            List<Room> sobe = _controller.getAllRooms();
            foreach (Room soba in sobe)
            {
               
            }

        }

    }
}
