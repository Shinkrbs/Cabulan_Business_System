using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Classes;
using MySql.Data.MySqlClient;

namespace Class_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;database=cabulan_database;user=root;password=;";

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                }
            }

            AuthService authService = new AuthService();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (authService.Login(username, password))
            {
                Console.WriteLine("✅ Login successful! Welcome, " + username);
            }
            else
            {
                Console.WriteLine("❌ Invalid username or password.");
            }
        }
    }
}
