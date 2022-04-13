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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void lekarLogIn(object sender, RoutedEventArgs e)
        {
            LekarWindow lekar = new LekarWindow();
            lekar.Show();
            this.Close();
        }

        private void PatientOptionsWin(object sender, RoutedEventArgs e)
        {
            PatientOptions patientOptions = new PatientOptions();
            patientOptions.Show();
            this.Close();
        }

        private void directorAddRoom(object sender, RoutedEventArgs e)
        {
            Rooms director = new Rooms();
            director.Show();
            this.Close();
        }
    }
}
