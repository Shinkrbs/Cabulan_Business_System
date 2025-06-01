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

namespace App_Project
{
    /// <summary>
    /// Interaction logic for MainDashboard.xaml
    /// </summary>
    public partial class MainDashboard : Window
    {
        public MainDashboard()
        {
            InitializeComponent();
        }
        private void OpenOrders(object sender, RoutedEventArgs e)
        {
            OrdersPage ordersWindow = new OrdersPage();
            ordersWindow.Show();
        }

        private void OpenCustomers(object sender, RoutedEventArgs e)
        {
            CustomerPage customerWindow = new CustomerPage();
            customerWindow.Show();
        }

        private void OpenEmployees(object sender, RoutedEventArgs e)
        {
            EmployeePage employeeWindow = new EmployeePage();
            employeeWindow.Show();
        }

        private void OpenSuppliers(object sender, RoutedEventArgs e)
        {
            SupplierPage supplierWindow = new SupplierPage();
            supplierWindow.Show();
        }
    }
}
