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
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {
        private Customer _selectedCustomer; 

        public UpdateCustomer(Customer customer)
        {
            InitializeComponent();
            _selectedCustomer = customer;

            NameBox.Text = _selectedCustomer.Name;
            AddressBox.Text = _selectedCustomer.Address;
            ContactBox.Text = _selectedCustomer.ContactInfo;
        }

        private void ConfirmUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all customer details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _selectedCustomer.Name = NameBox.Text;
            _selectedCustomer.Address = AddressBox.Text;
            _selectedCustomer.ContactInfo = ContactBox.Text;


            DialogResult = true;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
