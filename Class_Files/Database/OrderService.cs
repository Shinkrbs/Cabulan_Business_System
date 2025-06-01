using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Files.Database
{
    public class OrderService
    {
        private OrderRepository _orderRepo = new OrderRepository();
        private CustomerRepository _customerRepo = new CustomerRepository();

        public void ProcessOrder(int customerId, decimal totalAmount)
        {
            var customer = _customerRepo.GetCustomers().Find(c => c.Id == customerId);
            if (customer != null)
            {
                _orderRepo.PlaceOrder(customerId, totalAmount);
                Console.WriteLine($"Order placed successfully for {customer.Name}.");
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }
    }
}
