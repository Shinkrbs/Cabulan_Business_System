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

        public CustomOrder()
        {
            InitializeComponent();
            LoadCustomers();
            LoadEmployees();
        }

        private void LoadCustomers()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            CustomerComboBox.ItemsSource = customers;
            CustomerComboBox.DisplayMemberPath = "Name";
            CustomerComboBox.SelectedValuePath = "Id";
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
            if (CustomerComboBox.SelectedValue == null ||
                EmployeeComboBox.SelectedValue == null ||
                string.IsNullOrWhiteSpace(CustomOrderBox.Text) ||
                string.IsNullOrWhiteSpace(PriceBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityBox.Text))
            {
                MessageBox.Show("Please fill in all fields before submitting.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string description = CustomOrderBox.Text;
            if (!decimal.TryParse(PriceBox.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price input.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity < 1)
            {
                MessageBox.Show("Invalid quantity.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int empId = (int)EmployeeComboBox.SelectedValue;

            // You can swap this to a more appropriate repository if needed
            bool success = _customerRepo.AddProjectItem(description, price, quantity, empId);

            if (success)
            {
                MessageBox.Show("Custom order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("Failed to place custom order.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            CustomOrderBox.Text = string.Empty;
            PriceBox.Text = string.Empty;
            QuantityBox.Text = string.Empty;
            EmployeeComboBox.SelectedIndex = -1;
            CustomerComboBox.SelectedIndex = -1;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Allows only numeric input (e.g., for Quantity)
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        // Allows decimal input (e.g., for Price)
        private void DecimalOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            string currentText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            e.Handled = !decimal.TryParse(currentText, out _);
        }
        private void ViewOrders_Click(object sender, RoutedEventArgs e)
        {
            var ordersWindow = new CustomOrdersTableWindow(); // you'll create this window next
            ordersWindow.ShowDialog();
        }

    }
}
