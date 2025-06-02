using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Classes;
using MySql.Data.MySqlClient;

namespace Class_Files.Database
{
    public class SupplierRepository
    {
        private DatabaseConnection _db = new DatabaseConnection();

        public void AddSupplier(Supplier supplier)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO suppliers (name, address, contact_info) VALUES (@Name, @Address, @ContactInfo)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", supplier.Name);
                        cmd.Parameters.AddWithValue("@Address", supplier.Address);
                        cmd.Parameters.AddWithValue("@ContactInfo", supplier.ContactInfo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding supplier: {ex.Message}");
            }
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("name"), 
                                Address = reader.GetString("address"), 
                                ContactInfo = reader.GetString("contact_info") 
                            });
                        }
                    }
                }
                Console.WriteLine($"Retrieved {suppliers.Count} suppliers!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching suppliers: {ex.Message}");
            }
            return suppliers;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE suppliers SET name=@Name, address=@Address, contact_info=@ContactInfo WHERE Id=@Id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", supplier.Id);
                        cmd.Parameters.AddWithValue("@Name", supplier.Name);
                        cmd.Parameters.AddWithValue("@Address", supplier.Address);
                        cmd.Parameters.AddWithValue("@ContactInfo", supplier.ContactInfo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating supplier: {ex.Message}");
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM suppliers WHERE Id=@Id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", supplierId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting supplier: {ex.Message}");
            }
        }
    }
}
