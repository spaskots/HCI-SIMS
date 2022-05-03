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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        RecipeController recipeController = new RecipeController();
        List<int> recipeId = null;
        public CreateRecipe()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recipeId = recipeController.getAllId();
            int id;
            if (recipeId == null)
            {
                id = 0;
            }
            else
            {
                id = recipeId.Last();
                ++id;
            }
            String medicine = Medicine.Text;
            Double quantity;
            Double.TryParse(Quantity.Text, out quantity);
            String instruction = Instruction.Text;
            Double howOften;
            Double.TryParse(Howoften.Text, out howOften);
            String startTime =Starttime.Text;
            String idPatient = MedicalCard.medicalCard.patient.Id;
            if(Medicine.Text=="" || Quantity.Text=="" || Instruction.Text=="" || Howoften.Text=="" || Starttime.Text=="" )
            {
                MessageBox.Show("Greska");
                return;
            }
            RecipeR recipe = new RecipeR(id,medicine, quantity, instruction, howOften, startTime,idPatient);
            recipeController.save(recipe);
            Recipe r = new Recipe();
            r.Show();
            this.Close();

        }
    }
}
