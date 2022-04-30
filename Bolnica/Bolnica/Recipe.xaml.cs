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
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Window
    {
        RecipeController recipeController=new RecipeController();
        String patientId = MedicalCard.medicalCard.patient.Id;
        public static RecipeR recipe = null;
        
        public Recipe()
        {
            InitializeComponent();
           
            List<RecipeR> recipes = recipeController.getRecipeByPatientId(patientId);
            foreach(RecipeR rec in recipes)
            {

                RecipeView.Items.Add(rec);
            }
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CreateRecipe cr=new CreateRecipe();
            cr.Show();
            
        }
        private void change_Click(object sender, RoutedEventArgs e)
        {
            recipe =RecipeView.SelectedItem as RecipeR;
            
            ChangeRecipe cr=new ChangeRecipe();
            cr.Show();

        }
    }
   
}
