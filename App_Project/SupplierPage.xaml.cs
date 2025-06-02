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
    /// Interaction logic for SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Window
    {
        private SupplierRepository _supplierRepo = new SupplierRepository(); 

        public SupplierPage()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            List<Supplier> suppliers = _supplierRepo.GetSuppliers();

            if (suppliers.Count == 0)
            {
                SupplierDataGrid.ItemsSource = null;
                MessageBox.Show("No suppliers found.", "Supplier Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SupplierDataGrid.ItemsSource = suppliers;
            }
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            AddSupplier addSupplierWindow = new AddSupplier();
            addSupplierWindow.ShowDialog();
            LoadSuppliers(); 
        }

        private void UpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                UpdateSupplier updateSupplierWindow = new UpdateSupplier(selectedSupplier);
                bool? result = updateSupplierWindow.ShowDialog();

                if (result == true)
                {
                    _supplierRepo.UpdateSupplier(selectedSupplier);
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadSuppliers();
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to update.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                _supplierRepo.DeleteSupplier(selectedSupplier.Id);
                MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadSuppliers();
                LoadSuppliers();
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ContactSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                MessageBox.Show($"Contacting Supplier: {selectedSupplier.Name}\n📧 {selectedSupplier.ContactInfo}", "Contact Supplier", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a supplier to contact.", "Contact Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
