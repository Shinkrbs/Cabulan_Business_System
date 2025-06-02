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
        private OrderRepository _orderRepo = new OrderRepository();
        private EmployeeRepository _employeeRepo = new EmployeeRepository(); // ✅ Added Employee Repo

        public OrdersPage()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts(); // ✅ Ensure products are loaded
            LoadEmployees(); // ✅ Ensure employees are loaded
            LoadOrders();
        }

        private void LoadCustomers()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            CustomerComboBox.ItemsSource = customers;
            CustomerComboBox.DisplayMemberPath = "Name";
            CustomerComboBox.SelectedValuePath = "Id";
        }

        private void LoadProducts()
        {
            List<Product> products = _orderRepo.GetProducts();
            ProductComboBox.ItemsSource = products;
            ProductComboBox.DisplayMemberPath = "ProductName"; // ✅ Ensure product names are displayed
            ProductComboBox.SelectedValuePath = "ProductId";
        }

        private void LoadEmployees()
        {
            List<Employee> employees = _employeeRepo.GetEmployees();
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "Name"; // ✅ Ensure employee names are displayed
            EmployeeComboBox.SelectedValuePath = "EmpId";
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue == null || ProductComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(QuantityBox.Text) || EmployeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("❌ Please select a customer, product, employee, and enter quantity.", "Order Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int customerId = (int)CustomerComboBox.SelectedValue;
            int productId = (int)ProductComboBox.SelectedValue;
            int empId = (int)EmployeeComboBox.SelectedValue;

            if (!int.TryParse(QuantityBox.Text, out int quantity))
            {
                MessageBox.Show("❌ Invalid quantity format.", "Order Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _orderService.ProcessOrder(customerId, productId, quantity, empId);
            MessageBox.Show("✅ Order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            LoadOrders(); // ✅ Refresh order list after placing an order
        }

        private void LoadOrders()
        {
            List<Order> orders = _orderRepo.GetOrders();

            if (orders.Count == 0)
            {
                OrderDataGrid.ItemsSource = null;
                MessageBox.Show("No orders found.", "Order Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var enrichedOrders = orders.Select(o => new
                {
                    CustomerId = o.CustomerId,
                    TotalAmount = o.TotalAmount,
                }).ToList();

                OrderDataGrid.ItemsSource = enrichedOrders;
            }
        }


        private void CustomOrder_Click(object sender, RoutedEventArgs e)
        {
            CustomOrder customOrderWindow = new CustomOrder();
            customOrderWindow.ShowDialog();
        }

        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(QuantityBox.Text))
                return;

            int productId = (int)ProductComboBox.SelectedValue;
            decimal price = _orderRepo.GetProductPrice(productId);
            int quantity = int.Parse(QuantityBox.Text);

            TotalAmountBox.Text = (price * quantity).ToString("₱0.00"); // ✅ Calculate total dynamically
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
