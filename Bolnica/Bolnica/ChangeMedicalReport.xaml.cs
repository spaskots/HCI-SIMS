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
using Bolnica.Controller;
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for ChangeMedicalReport.xaml
    /// </summary>
    public partial class ChangeMedicalReport : Window
    {
        AnamnesisController anamnesisController=new AnamnesisController();
        int idAnamnesis = MedicalReport.a.Id;
        public ChangeMedicalReport()
        {
            InitializeComponent();
            
            Description.Text = MedicalReport.a.Description;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String description = Description.Text;
            anamnesisController.update(idAnamnesis, description);
            MedicalReport medicalReport = new MedicalReport();
            medicalReport.Show();
            this.Close();
        }
    }
}
