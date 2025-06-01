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
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Suppliers (Name, Address, ContactInfo) VALUES (@Name, @Address, @ContactInfo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", supplier.Name);
                    cmd.Parameters.AddWithValue("@Address", supplier.Address);
                    cmd.Parameters.AddWithValue("@ContactInfo", supplier.ContactInfo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Suppliers";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new Supplier
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            ContactInfo = reader.GetString("ContactInfo")
                        });
                    }
                }
            }
            return suppliers;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Suppliers SET Name=@Name, Address=@Address, ContactInfo=@ContactInfo WHERE Id=@Id";
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

        public void DeleteSupplier(int supplierId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Suppliers WHERE Id=@Id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", supplierId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
