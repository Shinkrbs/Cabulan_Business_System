using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_Files.Database
{
    public class DatabaseConnection
    {
        private string _connectionString = "server=localhost;database=cabulan_database;user=root;password=;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
