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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        private CustomerRepository _customerRepo = new CustomerRepository(); // ✅ Declare CustomerRepository

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void ConfirmAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all customer details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Customer newCustomer = new Customer
            {
                Name = NameBox.Text,
                Address = AddressBox.Text,
                ContactInfo = ContactBox.Text
            };

            _customerRepo.AddCustomer(newCustomer);
            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
