using AdoNetFundamentals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetConsole.Controllers
{
    internal class ProductsController
    {
        IProductRepository productRepository = new ProductRepository();
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            PopulateProducts();
            GetAllProducts();
            GetProductsByName("product1");
        }

        void GetProductsByName(string name)
        {
            Console.WriteLine("Get by product name");
            productRepository.GetProductByName(name);
            Console.WriteLine();
        }

        void GetAllProducts()
        {
            productRepository.GetAllProducts();
            Console.WriteLine();
        }
        void PopulateProducts()
        {
            Console.WriteLine("Populating tables:");
            productRepository.AddProduct("product1", "desc1", 12, 14, 10, 21);
            productRepository.AddProduct("product2", "desc2", 12, 14, 10, 21);
            productRepository.AddProduct("product3", "desc3", 12, 14, 10, 21);
            productRepository.AddProduct("product4", "desc4", 12, 14, 10, 21);
            Console.WriteLine();
        }
    }
}
