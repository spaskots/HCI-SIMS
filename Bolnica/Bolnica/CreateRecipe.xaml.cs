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
using Bolnica;
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        public CreateRecipe()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String medicine = Medicine.Text;
            Double quantity = Convert.ToDouble(Quantity.Text);
            String instruction = Instruction.Text;
            Double howOften = Convert.ToDouble(Howoften.Text);
            String startTime =Starttime.Text;
            String idPatient = MedicalCard.medicalCard.patient.Id;
            RecipeR recipe = new RecipeR(1,medicine, quantity, instruction, howOften, startTime,idPatient);


        }
    }
}
