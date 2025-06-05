using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Classes;
using MySql.Data.MySqlClient;

namespace Class_Files.Database
{
    public class CustomerRepository
    {
        private DatabaseConnection _db = new DatabaseConnection();

        public void AddCustomer(Customer customer)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Customers (Name, Address, ContactInfo) VALUES (@Name, @Address, @ContactInfo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@ContactInfo", customer.ContactInfo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customers";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            Id = reader.GetInt32("CustomerId"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            ContactInfo = reader.GetString("ContactInfo")
                        });
                    }
                }
            }
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Customers SET Name=@Name, Address=@Address, ContactInfo=@ContactInfo WHERE CustomerId=@CustomerId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customer.Id);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@ContactInfo", customer.ContactInfo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Customers WHERE CustomerId=@CustomerId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ New Method: Add a custom order linked to a customer
        public void AddCustomOrder(int orderId, int productId, int quantity, int empId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                // Get product price dynamically from `Products` table
                decimal price = GetProductPrice(productId);

                // Insert custom order into `project_items`
                string query = "INSERT INTO project_items (order_id, product_id, price, quantity, emp_id) VALUES (@OrderId, @ProductId, @Price, @Quantity, @EmpId)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Fetch product price dynamically
        private decimal GetProductPrice(int productId)
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
    }
}
