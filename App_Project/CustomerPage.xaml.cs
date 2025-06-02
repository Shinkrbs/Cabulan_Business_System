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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Window
    {
        private CustomerRepository _customerRepo = new CustomerRepository();

        public CustomerPage()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            CustomerDataGrid.ItemsSource = customers;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomerWindow = new AddCustomer(); 
            addCustomerWindow.ShowDialog();
            LoadCustomers();
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
  
                UpdateCustomer updateCustomerWindow = new UpdateCustomer(selectedCustomer);
                bool? result = updateCustomerWindow.ShowDialog(); 

                if (result == true)
                {
                    _customerRepo.UpdateCustomer(selectedCustomer); 
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomers(); 
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                _customerRepo.DeleteCustomer(selectedCustomer.Id);
                MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
