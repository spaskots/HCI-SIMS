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

namespace Bolnica.View
{
    /// <summary>
    /// Interaction logic for OrderDynamicEquipment.xaml
    /// </summary>
    public partial class OrderDynamicEquipment : Window
    {

        private DynamicEquipmentController _dynamicEquipmentController = new DynamicEquipmentController();
        private OrderController _orderController = new OrderController();

        private List<DynamicEquipment> dynamicEquipments = new List<DynamicEquipment>();
        public OrderDynamicEquipment()
        {
            InitializeComponent();
            dynamicEquipments = _dynamicEquipmentController.GetAllDynamicEquipments();

            foreach (DynamicEquipment dynamicEquipment in dynamicEquipments)
            {
                equipmentToOrder.Items.Add(dynamicEquipment.Id + ". " + dynamicEquipment.Name + ": {" + dynamicEquipment.Quantity + "}");
            }

            

        }


        private bool initState = true;
        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (initState)
            {
                textBox.Text = string.Empty;
                initState = false;
            }
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedEquipment = equipmentToOrder.SelectedIndex;
            int desiredAmount = Convert.ToInt32(AmountToOrder.Text);
            DynamicEquipment desiredEquipment = dynamicEquipments.ElementAt(selectedEquipment);

            if (desiredAmount <= 0 || desiredAmount > 100) { MessageBox.Show("Error: Number must be in range of 1-100"); return; }
            if (desiredEquipment == null) { MessageBox.Show("Error: No equipment has been selected!"); return; }

            if (!_orderController.IssueOrder(desiredEquipment, desiredAmount))
            {
                MessageBox.Show("Error: Couldn't issue the order!");
                return;
            } else
            {
                MessageBox.Show("Success: Successfully issued the order!");
                this.Close();
            }
        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == string.Empty)
            {
                textBox.Text = "Enter number...";
                initState = true;
            }
        }
    }
}
