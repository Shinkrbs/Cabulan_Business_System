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
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        private EmployeeRepository _employeeRepo = new EmployeeRepository();
        private Employee _selectedEmployee;

        public UpdateEmployee(Employee employee)
        {
            InitializeComponent();
            _selectedEmployee = employee;

            NameBox.Text = _selectedEmployee.Name;
            RoleBox.Text = _selectedEmployee.Role;
            ContactBox.Text = _selectedEmployee.ContactInfo;
        }

        private void ConfirmUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(RoleBox.Text) || string.IsNullOrWhiteSpace(ContactBox.Text))
            {
                MessageBox.Show("Please fill in all employee details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _selectedEmployee.Name = NameBox.Text;
            _selectedEmployee.Role = RoleBox.Text;
            _selectedEmployee.ContactInfo = ContactBox.Text;

            _employeeRepo.UpdateEmployee(_selectedEmployee);
            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
