using Bolnica.Controller;
using Bolnica.Model;
using Bolnica.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for SingleCurePage.xaml
    /// </summary>
    public partial class SingleCurePage : Page
    {
        public SingleCurePage(Cure cure)
        {
            InitializeComponent();
            IdEdit.Text = cure.Id.ToString();
            NameEdit.Text = cure.Name.ToString();
            QuantityEdit.Text = cure.Quantity.ToString();
            List<Ingredient> ingredients = _repository.getAllIngredientsForChosenCure(cure);
            foreach (Ingredient ingredient in ingredients)
            IngredientsView.Items.Add(ingredient);
        }
        CureRepository _repository = new CureRepository();
        CureController _controller = new CureController();
        
        private void backClick(object sender, RoutedEventArgs e)
        {

            SingleCurePageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("CuresSelected");

        }
        private void editRoom(object sender, RoutedEventArgs e)
        {
            iconEditName.Visibility = Visibility.Hidden;
            iconDeleteName.Visibility = Visibility.Hidden;
            iconSubmitEditName.Visibility = Visibility.Visible;

            NameEdit.IsEnabled = true;
            QuantityEdit.IsEnabled = true;
            HeaderTittleName.Content = "Edit Cure";
        }
        private void submitDeleteRoom(object sender, RoutedEventArgs e)
        {
            String id = IdEdit.Text;
            Cure cDelete = _repository.FindById(Int32.Parse(id));
            if (cDelete != null) { _controller.Delete(cDelete); }
            SingleCurePageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("CuresSelected");
            MessageBox.Show("Room Successfully Deleteted!");
        }
        private void submitEditRoom(object sender, RoutedEventArgs e)
        {
            String id = IdEdit.Text;
            String name = NameEdit.Text;


            String quantity = QuantityEdit.Text;
            try
            {
                Int16 i2 = Int16.Parse(quantity);
            }
            catch
            {
                MessageBox.Show("Quantity Must Be Number!");
                return;
            }
            Cure cure = new Cure(Int32.Parse(id), name, Int32.Parse(quantity));
            _controller.Update(cure);
            MessageBox.Show("Success!");
            SingleCurePageName.Visibility = Visibility.Hidden;
            PagesFrame.Content = new FourCardsView("CuresSelected");
        }
    }
}
