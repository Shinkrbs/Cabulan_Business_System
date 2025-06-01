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
using Class_Files.Database;
using MySql.Data.MySqlClient;

namespace App_Project
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Window
    {
        private OrderService _orderService = new OrderService();
        private CustomerRepository _customerRepo = new CustomerRepository();

        public OrdersPage()
        {
            InitializeComponent();
            LoadCustomers();
            LoadOrders();
        }

        private void LoadCustomers()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            CustomerComboBox.ItemsSource = customers;
            CustomerComboBox.DisplayMemberPath = "Name";
            CustomerComboBox.SelectedValuePath = "Id";
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(TotalAmountBox.Text))
            {
                MessageBox.Show("Please select a customer and enter the total amount.", "Order Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int customerId = (int)CustomerComboBox.SelectedValue;
            decimal totalAmount;

            if (!decimal.TryParse(TotalAmountBox.Text, out totalAmount))
            {
                MessageBox.Show("Invalid amount format.", "Order Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _orderService.ProcessOrder(customerId, totalAmount);
            MessageBox.Show("Order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            LoadOrders();
        }
        private void LoadOrders()
        {
            OrderRepository _orderRepo = new OrderRepository();
            List<Order> orders = _orderRepo.GetOrders();

            if (orders.Count == 0)
            {
                OrderDataGrid.ItemsSource = null;
                MessageBox.Show("No orders found.", "Order Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                OrderDataGrid.ItemsSource = orders; 
            }
        }
    }
}
