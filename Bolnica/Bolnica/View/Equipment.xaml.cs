﻿using System;
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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Window
    {
        public Equipment()
        {
            InitializeComponent();
            this.DataContext = this;
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

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            StaticEquipmentRooms page = new StaticEquipmentRooms();
            page.Show();
            this.Close();

        }
    }
}
