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
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            ContactInfo = reader.GetString("ContactInfo")
                        });
                    }
                }
            }
            return customers;
        }
    }
}
