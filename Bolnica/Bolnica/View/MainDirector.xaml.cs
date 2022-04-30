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
    /// Interaction logic for MainDirector.xaml
    /// </summary>
    public partial class MainDirector : Window
    {
        public MainDirector()
        {
            InitializeComponent();
        }
        private void roomPage(object sender, MouseButtonEventArgs e)
        {
            PagesFrame.Content = new FourCardsView("PrikazSoba");

        }
        private void equipment(object sender, MouseButtonEventArgs e)
        {
            PagesFrame.Content = new FourCardsView("StaticEquipmentSelected");
        }
        private void moveExe(object sender, MouseButtonEventArgs e)
        { 
        }
    }
}
