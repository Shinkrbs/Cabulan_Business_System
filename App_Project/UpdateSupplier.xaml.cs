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
    /// Interaction logic for UpdateSupplier.xaml
    /// </summary>
    public partial class UpdateSupplier : Window
    {
        private SupplierRepository _supplierRepo = new SupplierRepository(); 
        private Supplier _selectedSupplier; 

        public UpdateSupplier(Supplier supplier)
        {
            InitializeComponent();
            _selectedSupplier = supplier;

            NameBox.Text = _selectedSupplier.Name;
            AddressBox.Text = _selectedSupplier.Address;
            ContactBox.Text = _selectedSupplier.ContactInfo;
        }

        private void ConfirmUpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(AddressBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all supplier details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _selectedSupplier.Name = NameBox.Text;
            _selectedSupplier.Address = AddressBox.Text;
            _selectedSupplier.ContactInfo = ContactBox.Text;

            _supplierRepo.UpdateSupplier(_selectedSupplier); 
            MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true; 
            this.Close(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
