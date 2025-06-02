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

namespace App_Project
{
    /// <summary>
    /// Interaction logic for CustomOrder.xaml
    /// </summary>
    public partial class CustomOrder : Window
    {
        private EmployeeRepository _employeeRepo = new EmployeeRepository();
        private CustomerRepository _customerRepo = new CustomerRepository();
        private OrderRepository _orderRepo = new OrderRepository();

        public CustomOrder()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts();
            LoadEmployees();
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
            ProductComboBox.DisplayMemberPath = "ProductName";
            ProductComboBox.SelectedValuePath = "ProductId";
        }

        private void LoadEmployees()
        {
            List<Employee> employees = _employeeRepo.GetEmployees();
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.DisplayMemberPath = "Name";
            EmployeeComboBox.SelectedValuePath = "EmpId";
        }

        private void ConfirmCustomOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedValue == null || ProductComboBox.SelectedValue == null || EmployeeComboBox.SelectedValue == null || string.IsNullOrWhiteSpace(QuantityBox.Text))
            {
                MessageBox.Show("Please select a customer, product, employee, and enter quantity.", "Order Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int orderId = _orderRepo.GetLastOrderId(); // 
            int productId = (int)ProductComboBox.SelectedValue;
            int empId = (int)EmployeeComboBox.SelectedValue;
            int quantity = int.Parse(QuantityBox.Text);

            _customerRepo.AddCustomOrder(orderId, productId, quantity, empId); 

            MessageBox.Show("✅ Custom order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
