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
    /// Interaction logic for CreateMedicalReport.xaml
    /// </summary>
    public partial class CreateMedicalReport : Window
    {
        AnamnesisController anamnesisController=new AnamnesisController();
        MedicalCardController medicalCardController=new MedicalCardController();
        List<int> anamnesisId = null;
        public CreateMedicalReport()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            anamnesisId = anamnesisController.getAllId();
            if (anamnesisId == null)
            {
                id = 0;
            }
            else
            {
                id = anamnesisId.Last();
                ++id;
            }
            String idPatient = MedicalCard.medicalCard.patient.Id;
          
            int idAppointment = LekarPocetna.ma.id;
            String description = Description.Text;
            String date = "12.12.2012";
            MedCard medCard = medicalCardController.getOneByPatientId(idPatient);
            Anamnesis anamnesis = new Anamnesis(id,idAppointment,description,date,medCard);
            anamnesisController.saveOne(anamnesis);
        }
    }
}
