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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MedicalReport.xaml
    /// </summary>
    public partial class MedicalReport : Window
    {
        public MedicalReport()
        {
            InitializeComponent();
           
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            this.Close();
        }
    }
}
