using AdoNetConsole.Controllers;
using AdoNetFundamentals;
using AdoNetFundamentals.Repositories;
//1. To run the application make sure to change path variable in SeedExtension 
//2. Create database in any sql server
//3. modify connection string in appsettings
SeedExtension.CreateTables();

IProductRepository productRepository = new ProductRepository();
IOrderRepository orderRepository = new OrderRepository();

ProductsController productsController = new ProductsController(productRepository);
OrdersController ordersController = new OrdersController(orderRepository);








