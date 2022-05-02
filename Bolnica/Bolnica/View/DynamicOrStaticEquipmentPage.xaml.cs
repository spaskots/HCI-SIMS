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
    /// Interaction logic for DynamicOrStaticEquipmentPage.xaml
    /// </summary>
    public partial class DynamicOrStaticEquipmentPage : Page
    {
        StaticEquipmentRepository staticEquipment_repository = new StaticEquipmentRepository();
        public DynamicOrStaticEquipmentPage()
        {
            InitializeComponent();
            Boolean zavrsio = staticEquipment_repository.MoveExecutionDo();
            if (zavrsio == true) { MessageBox.Show("Proverio da li ima nesto da se premsta!"); }
        }
        private void staticEquipmentPage(object sender, MouseButtonEventArgs e)
        {
            DynamicOrStaticEquipmentPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("StaticEquipmentSelected");
        }
        private void dynamicEquipmentPage(object sender, MouseButtonEventArgs e)
        {
            DynamicOrStaticEquipmentPageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("DynamicEquipmentSelected");
        }
        
    }
}
