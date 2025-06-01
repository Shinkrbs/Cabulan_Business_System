using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Database;
using MySql.Data.MySqlClient;

namespace Class_Files.Classes
{
    public class AuthService
    {
        private DatabaseConnection _db = new DatabaseConnection();

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool Login(string username, string password)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Username=@Username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString("PasswordHash");
                            return storedHash == HashPassword(password);
                        }
                    }
                }
            }
            return false;
        }
    }
}
