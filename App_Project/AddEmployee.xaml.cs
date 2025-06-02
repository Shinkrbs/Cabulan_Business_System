using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Class_Files.Classes;
using Class_Files.Database;

namespace App_Project
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private EmployeeRepository _employeeRepo = new EmployeeRepository(); 

        public AddEmployee()
        {
            InitializeComponent();
        }

        private void ConfirmAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(RoleBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all employee details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee newEmployee = new Employee
            {
                Name = NameBox.Text,
                Role = RoleBox.Text,
                ContactInfo = ContactBox.Text
            };

            _employeeRepo.AddEmployee(newEmployee); 
            MessageBox.Show("Employee added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); 
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
