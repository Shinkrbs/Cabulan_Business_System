using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for CustomOrdersTableWindow.xaml
    /// </summary>
    public partial class CustomOrdersTableWindow : Window
    {
        private readonly DatabaseConnection _db = new DatabaseConnection();

        public CustomOrdersTableWindow()
        {
            InitializeComponent();
            LoadCustomOrders();
        }

        private void LoadCustomOrders()
        {
            var items = new List<ProjectItem>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT OrderId, ProductDescription, Price, Quantity FROM ProjectItems";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ProjectItem
                        {
                            OrderId = reader.GetInt32("OrderId"), // maps to Id (primary key)
                            ProductDescription = reader.GetString("ProductDescription"),
                            Price = reader.GetDecimal("Price"),
                            Quantity = reader.GetInt32("Quantity")
                        });
                    }
                }
            }

            OrdersDataGrid.ItemsSource = items;
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is ProjectItem selected)
            {
                // Launch editable update window
                UpdateCustomOrder updateWindow = new UpdateCustomOrder(selected);
                bool? result = updateWindow.ShowDialog();

                if (result == true)
                {
                    using (var conn = _db.GetConnection())
                    {
                        conn.Open();
                        string query = @"UPDATE ProjectItems 
                                 SET ProductDescription = @desc, Price = @price, Quantity = @qty 
                                 WHERE OrderId = @id";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@desc", selected.ProductDescription);
                            cmd.Parameters.AddWithValue("@price", selected.Price);
                            cmd.Parameters.AddWithValue("@qty", selected.Quantity);
                            cmd.Parameters.AddWithValue("@id", selected.OrderId);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Order updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadCustomOrders();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is ProjectItem selected)
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM ProjectItems WHERE OrderId = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selected.OrderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Order deleted successfully!", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadCustomOrders();
            }
            else
            {
                MessageBox.Show("Please select an order to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
