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

        public void PlaceOrder(int customerId, decimal totalAmount)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO order_projects (Id, customerid, orderdate, totalamount) VALUES (@CustomerId, @OrderDate, @TotalAmount)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.ExecuteNonQuery();
                }
            }
        }

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
    }
}
