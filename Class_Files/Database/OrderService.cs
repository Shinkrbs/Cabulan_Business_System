using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Files.Classes;

namespace Class_Files.Database
{
    public class OrderService
    {
        private OrderRepository _orderRepo = new OrderRepository();
        private CustomerRepository _customerRepo = new CustomerRepository();

        public void ProcessOrder(int customerId, int productId, int quantity, int empId)
        {
            var customer = _customerRepo.GetCustomers().Find(c => c.Id == customerId);
            if (customer == null)
            {
                Console.WriteLine("❌ Customer not found!");
                return;
            }

            // ✅ Correctly retrieve product price and calculate total amount
            decimal price = _orderRepo.GetProductPrice(productId);
            decimal totalAmount = price * quantity; // ✅ Calculate total dynamically

            // ✅ Match `OrderRepository.PlaceOrder()` argument structure
            _orderRepo.PlaceOrder(customerId, totalAmount, productId, quantity, empId);
            Console.WriteLine($"✅ Order placed successfully for {customer.Name} with Product ID {productId} and Quantity {quantity}.");
        }


        // ✅ Retrieve all orders with customer details
        public List<Order> GetOrders()
        {
            return _orderRepo.GetOrders();
        }

        // ✅ Retrieve last order ID for linking custom orders
        public int GetLastOrderId()
        {
            return _orderRepo.GetLastOrderId();
        }
    }
}
