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
using Bolnica.Model;
using Bolnica.Controller;
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MedicalReport.xaml
    /// </summary>
    public partial class MedicalReport : Window
    {
        AnamnesisController anamnesisController=new AnamnesisController();
        public static Anamnesis a = null;
        public MedicalReport()
        {
            InitializeComponent();
            int idMedicalCard = MedicalCard.medicalCard.Id;
            List<Anamnesis> anamnesis = anamnesisController.getAllByMedicalCard(idMedicalCard);
            foreach(Anamnesis a in anamnesis)
            {
                MedicalReportView.Items.Add(a);
            }
            
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CreateMedicalReport cmr=new CreateMedicalReport();
            cmr.Show();
        }
        private void change_Click(object sender, RoutedEventArgs e)
        {
            a = MedicalReportView.SelectedItem as Anamnesis;
            ChangeMedicalReport cmr=new ChangeMedicalReport();
            cmr.Show();
            this.Close();

        }
    }
}
