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
    /// Interaction logic for AddNewRoom.xaml
    /// </summary>
    public partial class AddNewRoom : Page
    {
        String onButtonClick; 
        public AddNewRoom(String mark )
        {
            InitializeComponent();
            if (mark == "AddNewRoom")
            {
                onButtonClick = "AddNewRoom";
                this.DataContext = this;
                Int16 minId = 1;
                Int16 temp = 1;
                ID = "1";
                List<Room> sobe = _controller.getAllRooms();
                foreach (Room soba in sobe)
                {
                    if (soba == null) { return; }
                    temp = Int16.Parse(soba.Id);
                    if (temp > minId) { minId = temp; }
                }
                minId += 1;

                idTextBoxName.Text = minId.ToString();
            }
            else if (mark == "AddNewCure") {
                onButtonClick = "AddNewCure";
                HeaderTittleName.Content = "Add New Cure";
                RoomAddNewAttributesName.Visibility = Visibility.Hidden;
                QuantityOrFloorLabelName.Content = "Quantity:";
                idTextBoxName.Text = cure_repository.GenerateNewCureId().ToString(); // Zasto ne radi ? 
                ListIngredientsName.Visibility = Visibility.Visible;

                List<Ingredient> ingredients = ingredient_controller.GetAllIngredients();

                foreach (Ingredient ingredient in ingredients)
                {
                    IngredientsView.Items.Add(ingredient);
                }

            }
        }
        IngredientController ingredient_controller = new IngredientController();
        IngredientRepository ingredient_repository = new IngredientRepository();
        CureController cure_controller = new CureController();
        CureRepository cure_repository = new CureRepository();
        RoomController _controller = new RoomController();
        RoomRepository _repository = new RoomRepository();

        public object ID { get; set; }
        private void addRoomSubmit(object sender, RoutedEventArgs e)
        {

            String id = idTextBoxName.Text.ToString();
            String name = nameTextBoxName.Text.ToString();
            String floorQuantity = FloorOrQuantity.Text.ToString();
            try
            {
                Int16 i2 = Int16.Parse(floorQuantity);   // Error
                if (floorQuantity == null) { return; }
            }
            catch
            {
                MessageBox.Show("Third Input Must Be Number!");
                return;
            }
            if (onButtonClick == "AddNewRoom") 
            {
                try
                {
                    Int16 i2 = Int16.Parse(id);   // Error
                    Room roomProvera = _repository.FindById(id);
                    if (roomProvera != null) { MessageBox.Show("ID already exists!"); return; }
                }
                catch
                {
                    MessageBox.Show("Invalid ID!");
                    return;
                }
                if (name.Length > 3) { MessageBox.Show("Name should have less than three characters!"); return; }
                String troom = typeRoom.Text.ToString();
                RoomType roomType;
                if (troom == "Operation Room") { roomType = RoomType.OperationRoom; }
                else if (troom == "Cancer Room") { roomType = RoomType.CancerRoom; }
                else if (troom == "Rest Room") { roomType = RoomType.RestRoom; }
                else { roomType = RoomType.CovidRoom; }
                String description = Description.Text.ToString();
                
                Room room = new Room(id, name, floorQuantity, description, roomType);
                _controller.Create(room);
                MessageBox.Show("Successfully added room!");
                AddNewPageContent.Visibility = Visibility.Hidden;
                PagesFrame.Content = new FourCardsView("PrikazSoba");
            }
            if(onButtonClick == "AddNewCure")
            {
                try
                {
                    Int16 i2 = Int16.Parse(id);   // Error
                    Cure cureCheck = cure_repository.FindById(Int32.Parse(id));
                    if (cureCheck != null) { MessageBox.Show("ID already exists!"); return; }
                }
                catch
                {
                    MessageBox.Show("Invalid ID!");
                    return;
                }
                Cure cure = new Cure(Int32.Parse(id), name, Int16.Parse(floorQuantity));
                cure_controller.AddCure(cure);

                cure_repository.AddCureIngredients(Int32.Parse(id), cureIngredients);
                MessageBox.Show("Successfully Added Cure And Ingredients!");

                AddNewPageContent.Visibility = Visibility.Hidden;
                PagesFrame.Content = new FourCardsView("CuresSelected");
            }

        }
        private void goBack(object sender, RoutedEventArgs e)
        {
            if (onButtonClick == "AddNewRoom")
            {
                AddNewPageContent.Visibility = Visibility.Hidden;
                PagesFrame.Content = new FourCardsView("PrikazSoba");
            }
            else if(onButtonClick == "AddNewCure")
            {
                AddNewPageContent.Visibility = Visibility.Hidden;
                PagesFrame.Content = new FourCardsView("CuresSelected");
            }
        }


        List<Ingredient> cureIngredients = new List<Ingredient>();
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = (Ingredient)IngredientsView.SelectedItem as Ingredient;
            cureIngredients.Add(ingredient);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = (Ingredient)IngredientsView.SelectedItem as Ingredient;
            cureIngredients.Remove(ingredient);
        }
    }
}
