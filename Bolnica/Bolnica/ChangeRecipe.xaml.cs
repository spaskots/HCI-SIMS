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
using Bolnica.Model;
namespace Bolnica
{
    /// <summary>
    /// Interaction logic for ChangeRecipe.xaml
    /// </summary>
    public partial class ChangeRecipe : Window
    {
        RecipeController recipeController = new RecipeController();
       
        public ChangeRecipe()
        {
            InitializeComponent();
            
            Medicine.Text = Recipe.recipe.medicine;
            Quantity.Text = Recipe.recipe.quantity.ToString();
            Instruction.Text = Recipe.recipe.instruction;
            Howoften.Text = Recipe.recipe.howOften.ToString();
            Starttime.Text = Recipe.recipe.startTime;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            String medicine=Medicine.Text;
            Double quantity=Convert.ToDouble(Quantity.Text);
            String instruction=Instruction.Text;
            Double howOften=Convert.ToDouble(Howoften.Text);
            String startTime=Starttime.Text;
           int id=Recipe.recipe.id;
            String idPatient = Recipe.recipe.patient.Id;
            RecipeR recipe = new RecipeR(id, medicine, quantity, instruction, howOften, startTime,idPatient);
            recipeController.update(recipe);
            Recipe r = new Recipe();
            r.Show();
            this.Close();

        }
    }
}
