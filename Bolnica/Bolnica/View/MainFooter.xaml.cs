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
    /// Interaction logic for MainFooter.xaml
    /// </summary>
    public partial class MainFooter : Page
    {
        public MainFooter()
        {
            InitializeComponent();
        }
        private void roomPage(object sender, MouseButtonEventArgs e)
        {
            RoomPage director = new RoomPage();
            director.Show();

        }
        private void equipment(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
