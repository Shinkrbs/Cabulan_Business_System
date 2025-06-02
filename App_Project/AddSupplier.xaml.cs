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
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        private SupplierRepository _supplierRepo = new SupplierRepository(); 

        public AddSupplier()
        {
            InitializeComponent();
        }

        private void ConfirmAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all supplier details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Supplier newSupplier = new Supplier
            {
                Name = NameBox.Text,
                Address = AddressBox.Text,
                ContactInfo = ContactBox.Text
            };

            _supplierRepo.AddSupplier(newSupplier); 
            MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
