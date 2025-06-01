using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Class_Files.Classes;
using Class_Files.Database;
using MySql.Data.MySqlClient;

namespace App_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseConnection _db = new DatabaseConnection();
        public MainWindow()
        {
            InitializeComponent();
            CheckDatabaseConnection();
        }

        private void CheckDatabaseConnection()
        {
            using (var conn = _db.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connected to the database successfully!", "Database Connection", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection failed!\nError: " + ex.Message, "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();  // Close the application if connection fails
                }
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthService authService = new AuthService();
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            if (authService.Login(username, password))
            {
                MessageBox.Show("Login Successful!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                // Open main dashboard
                MainDashboard dashboard = new MainDashboard();
                dashboard.Show();
                this.Close();  // Close login window
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
