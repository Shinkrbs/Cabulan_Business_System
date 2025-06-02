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
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        private EmployeeRepository _employeeRepo = new EmployeeRepository();

        public EmployeePage()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeeDataGrid.ItemsSource = null; 
            EmployeeDataGrid.ItemsSource = _employeeRepo.GetEmployees(); 
            EmployeeDataGrid.Items.Refresh();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWindow = new AddEmployee();
            addEmployeeWindow.ShowDialog();
            LoadEmployees();
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                UpdateEmployee updateEmployeeWindow = new UpdateEmployee(selectedEmployee);
                bool? result = updateEmployeeWindow.ShowDialog();

                if (result == true)
                {
                    _employeeRepo.UpdateEmployee(selectedEmployee);
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to update.", "Update Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                _employeeRepo.DeleteEmployee(selectedEmployee.EmpId);
                MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadEmployees();
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
