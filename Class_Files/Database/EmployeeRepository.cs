using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Classes;
using MySql.Data.MySqlClient;

namespace Class_Files.Database
{
    public class EmployeeRepository
    {
        private DatabaseConnection _db = new DatabaseConnection();

        public void AddEmployee(Employee employee)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Employees (Name, Role, ContactInfo) VALUES (@Name, @Role, @ContactInfo)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Role", employee.Role);
                    cmd.Parameters.AddWithValue("@ContactInfo", employee.ContactInfo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Employees";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmpId = reader.GetInt32("EmpId"),
                            Name = reader.GetString("Name"),
                            Role = reader.GetString("Role"),
                            ContactInfo = reader.GetString("ContactInfo")
                        });
                    }
                }
            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Employees SET Name=@Name, Role=@Role, ContactInfo=@ContactInfo WHERE EmpId=@EmpId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Role", employee.Role);
                    cmd.Parameters.AddWithValue("@ContactInfo", employee.ContactInfo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int empId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Employees WHERE EmpId=@EmpId";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
