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

                // Get all OrderIds for this Customer
                List<int> orderIds = new List<int>();
                string getOrders = "SELECT Id FROM order_projects WHERE CustomerId = @CustomerId";
                using (var getCmd = new MySqlCommand(getOrders, conn))
                {
                    getCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = getCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderIds.Add(reader.GetInt32("Id"));
                        }
                    }
                }

                // Delete from projectsuppliers linked to each order
                foreach (var orderId in orderIds)
                {
                    string deleteSuppliers = "DELETE FROM projectsuppliers WHERE OrderId = @OrderId";
                    using (var cmd = new MySqlCommand(deleteSuppliers, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Delete from ProjectItems
                foreach (var orderId in orderIds)
                {
                    string deleteItems = "DELETE FROM ProjectItems WHERE OrderId = @OrderId";
                    using (var cmd = new MySqlCommand(deleteItems, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Delete from order_projects
                string deleteOrders = "DELETE FROM order_projects WHERE CustomerId = @CustomerId";
                using (var cmd = new MySqlCommand(deleteOrders, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                }

                // Delete the customer
                string deleteCustomer = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                using (var cmd = new MySqlCommand(deleteCustomer, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ New Method: Add a custom order linked to a customer
        public bool AddProjectItem(string description, decimal price, int quantity, int empId)
        {
            using (var conn = _db.GetConnection())
            {
                string query = @"INSERT INTO ProjectItems (ProductDescription, Price, Quantity, EmpId)
                         VALUES (@desc, @price, @qty, @empId)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    cmd.Parameters.AddWithValue("@empId", empId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
