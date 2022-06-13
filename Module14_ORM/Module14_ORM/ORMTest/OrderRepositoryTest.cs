using EF_API.Controllers;
using EF_API.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMTest
{
    public class OrderRepositoryTest
    {
        private readonly Mock<IOrderRepository> repository;
        public OrderRepositoryTest()
        {
            repository = new Mock<IOrderRepository>();
        }

        [Fact]
        public void CreateOrder_CreatedStatus_PassingOrderObjectToCreate()
        {
            var orders = GetSampleOrdersAsync();
            var newOrder = orders.Result[0];
            var controller = new OrdersController(repository.Object);
            var actionResult = controller.Create(newOrder);
            var result = actionResult.Result;
            Assert.IsType<CreatedResult>(result);
        }

        private async Task<List<Order>> GetSampleOrdersAsync()
        {
            List<Order> products = new List<Order>()
            {
                new Order
                {
                      Id = 1,
                      Status = Models.enums.Status.NotStarted,
                      ProductId = 1
                },
                new Order
                {
                      Id = 2,
                      Status = Models.enums.Status.Loading,
                      ProductId = 2
                }
            };
            return products;
        }
    }
}
