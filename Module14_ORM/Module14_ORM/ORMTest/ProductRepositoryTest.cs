using EF_API.Controllers;
using EF_API.DAL.Repositories;
using FluentAssertions;
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
    public class ProductRepositoryTest
    {
        private readonly Mock<IProductRepository> repository;
        public ProductRepositoryTest()
        {
            repository = new Mock<IProductRepository>();
        }

        [Fact]
        public void GetAll_ListOfProducts_ProductsExist()
        {
            var products = GetSampleProductsAsync();
            repository.Setup(x => x.GetAll())
                .Returns(products);
            var controller = new ProductsController(repository.Object);

            //act
            var actionResult = controller.GetAll();
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<Product>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(products.Result.Count(), actual.Count());
        }

        [Fact]
        public async Task GetProductById_ProductObject_ProductwithSpecificIdExists()
        {
            //arrange
            var product = GetProductAsync();
            repository.Setup(x => x.GetById(1))
                .Returns(product);
            var controller = new ProductsController(repository.Object);

            //act
            var actionResult = controller.GetById(2);
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        private async Task<List<Product>> GetSampleProductsAsync()
        {
            List<Product> products =  new List<Product>()
            {
                new Product
                {
                Id = 1,
                Name = "product1",
                Description = "desc1",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
                },
                new Product
                {
                Id = 2,
                Name = "product2",
                Description = "desc2",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
                }
            };
            return  products;
        }
        private async Task<Product> GetProductAsync()
        {
            return new Product
            {
                Id = 2,
                Name = "product2",
                Description = "desc2",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
            };
        }
    }
}
