using AdoNetFundamentals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetConsole.Controllers
{
    public class OrdersController
    {
        IOrderRepository orderRepository = new OrderRepository();
        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            PopulateOrders();
            GetAllOrders();
            BulkDeleteOrdersById();
            GetOrderByMonth("6");
            GetOrderByStatus("arrived");
        }
        void PopulateOrders()
        {
            Console.WriteLine("Populating Orders");
            orderRepository.AddOrder(DateTime.Now, DateTime.Now.AddMinutes(1), "NotStarted", 1);
            orderRepository.AddOrder(DateTime.Now, DateTime.Now.AddMinutes(1), "Loading", 2);
            orderRepository.AddOrder(DateTime.Now, DateTime.Now.AddMinutes(1), "InProgress", 3);
            orderRepository.AddOrder(DateTime.Now, DateTime.Now.AddMinutes(1), "Arrived", 4);
            Console.WriteLine();
        }
        void GetAllOrders()
        {
            orderRepository.GetAllOrders();
            Console.WriteLine();
        }
        void BulkDeleteOrdersById()
        {
            Console.WriteLine("Deleting orders by Ids");
            List<int> ids = new();
            ids.Add(1006);
            ids.Add(1007);
            orderRepository.BulkDeleteOrderById(ids);
            Console.WriteLine();
        }

        void GetOrderByMonth(string monthNumber)
        {
            Console.WriteLine("Getting Order by month");
            orderRepository.GetOrderByCreatedDateMonth(monthNumber);
            Console.WriteLine();
        }

        void GetOrderByStatus(string status)
        {
            Console.WriteLine("Order by status");
            orderRepository.GetOrderByStatus(status);
            Console.WriteLine();
        }
    }
}
