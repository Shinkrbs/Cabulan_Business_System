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
using Class_Files.Classes;

namespace App_Project
{
    /// <summary>
    /// Interaction logic for UpdateCustomOrder.xaml
    /// </summary>
    public partial class UpdateCustomOrder : Window
    {
        private ProjectItem _selectedOrder;

        public UpdateCustomOrder(ProjectItem item)
        {
            InitializeComponent();
            _selectedOrder = item;

            ProductDescriptionBox.Text = _selectedOrder.ProductDescription;
            PriceBox.Text = _selectedOrder.Price.ToString("F2");
            QuantityBox.Text = _selectedOrder.Quantity.ToString();
        }

        private void ConfirmUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductDescriptionBox.Text) ||
                string.IsNullOrWhiteSpace(PriceBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityBox.Text))
            {
                MessageBox.Show("Please fill in all order details.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(PriceBox.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price input.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity < 1)
            {
                MessageBox.Show("Invalid quantity input.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _selectedOrder.ProductDescription = ProductDescriptionBox.Text;
            _selectedOrder.Price = price;
            _selectedOrder.Quantity = quantity;

            DialogResult = true;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
