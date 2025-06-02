using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Class_Files.Classes;

namespace Class_Files.Database
{
    public class OrderRepository
    {
        private DatabaseConnection _db = new DatabaseConnection();

        // ✅ Updated: Places an order with product price dynamically retrieved
        public void PlaceOrder(int customerId, decimal totalAmount, int productId, int quantity, int empId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                // Insert order first
                string orderQuery = "INSERT INTO order_projects (customer_id, order_date, total_amount) VALUES (@CustomerId, @OrderDate, @TotalAmount)";
                using (var orderCmd = new MySqlCommand(orderQuery, conn))
                {
                    orderCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    orderCmd.ExecuteNonQuery();
                }

                long orderId;
                using (var idCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    orderId = Convert.ToInt64(idCmd.ExecuteScalar());
                }

                // Retrieve product price from `Products` table
                decimal price = GetProductPrice(productId);

                // Insert product linked to this order
                string itemQuery = "INSERT INTO project_items (order_id, product_id, price, quantity, emp_id) VALUES (@OrderId, @ProductId, @Price, @Quantity, @EmpId)";
                using (var itemCmd = new MySqlCommand(itemQuery, conn))
                {
                    itemCmd.Parameters.AddWithValue("@OrderId", orderId);
                    itemCmd.Parameters.AddWithValue("@ProductId", productId);
                    itemCmd.Parameters.AddWithValue("@Price", price);
                    itemCmd.Parameters.AddWithValue("@Quantity", quantity);
                    itemCmd.Parameters.AddWithValue("@EmpId", empId);
                    itemCmd.ExecuteNonQuery();
                }
            }
        }


        // Retrieve all orders with customer ID & total amount
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM order_projects";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = reader.GetInt32("Id"),
                            CustomerId = reader.GetInt32("customer_id"),
                            OrderDate = reader.GetDateTime("order_date"),
                            TotalAmount = reader.GetDecimal("total_amount")
                        });
                    }
                }
            }
            return orders;
        }

        // Retrieves product NAMES instead of IDs for a specific order
        public string GetProductsForOrder(int orderId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT GROUP_CONCAT(p.ProductName SEPARATOR ', ') 
                    FROM project_items pi 
                    JOIN products p ON pi.product_id = p.ProductId 
                    WHERE pi.order_id = @OrderId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "No products found";
                }
            }
        }


        // New Method: Retrieve product price dynamically
        public decimal GetProductPrice(int productId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT Price FROM Products WHERE ProductId = @ProductId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        // Retrieves all products for dropdown selection
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT ProductId, ProductName, Price, StockQuantity FROM Products"; 
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32("ProductId"),
                            ProductName = reader.GetString("ProductName"),
                            Price = reader.GetDecimal("Price"),
                            StockQuantity = reader.GetInt32("StockQuantity") 
                        });
                    }
                }
            }
            return products;
        }

        // Retrieve last order ID for custom order linking
        public int GetLastOrderId()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("SELECT MAX(Id) FROM order_projects", conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
