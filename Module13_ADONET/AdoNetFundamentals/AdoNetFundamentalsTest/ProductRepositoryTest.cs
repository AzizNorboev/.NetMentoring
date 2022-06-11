using AdoNetFundamentals.Entities;
using AdoNetFundamentals.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace AdoNetFundamentalsTest
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private Mock<IProductRepository> productRepository;
        private Mock<IOrderRepository> orderRepository;

        [SetUp]
        public void Setup()
        {
            productRepository = new Mock<IProductRepository>();
            orderRepository = new Mock<IOrderRepository>();
        }

        [Test]
        public void GetAllProductsReturnProductList()
        {
            List<Product> products = new List<Product> { new Product("Test Name", "Test Description", 34, 234, 654, 123) };
            var result = productRepository.Setup(x => x.GetAllProducts()).Returns(products);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetProductByNameReturnsProduct()
        {
            string productName = "Test Name";
            Product product = new Product(productName, "Test Description", 34, 234, 654, 123);
            var result = productRepository.Setup(x => x.GetProductByName(productName)).Returns(product);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllProductsReturnOrderList()
        {
            List<Order> orders = new List<Order> { new Order(DateTime.Now, DateTime.Now, Status.Arrived, 123) };
            var result = orderRepository.Setup(x => x.GetAllOrders()).Returns(orders);
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetOrderByStatus()
        {
            List<Order> orders = new List<Order> { new Order(DateTime.Now, DateTime.Now, Status.Arrived, 123) };
            var result = orderRepository.Setup(x => x.GetOrderByStatus("Arrived")).Returns(orders);
        }
    }
}