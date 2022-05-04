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

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for StaticEquipmentRooms.xaml
    /// </summary>
    public partial class StaticEquipmentRooms : Window
    {
        StaticEquipmentController _controller = new StaticEquipmentController();
        StaticEquipmentRepository _repository = new StaticEquipmentRepository();
        public StaticEquipmentRooms()
        {
            InitializeComponent();
            List<StaticEquipment> se = _controller.getAllStaticEquipment();
            String svaOpremaUkratko = "";
            foreach(StaticEquipment s in se) {
                svaOpremaUkratko += s.Name + "  ";
            }
            AllStaticEquipmentName.Text = svaOpremaUkratko;
        }
    }
}
