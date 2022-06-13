using AdoNetConsole.Controllers;
using AdoNetFundamentals;
using AdoNetFundamentals.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//configuration
CreateDefaultBuilder().Build();

SeedExtension.CreateTables();

IProductRepository productRepository = new ProductRepository();
IOrderRepository orderRepository = new OrderRepository();

ProductsController productsController = new ProductsController(productRepository);
OrdersController ordersController = new OrdersController(orderRepository);
Console.ReadLine();
static IHostBuilder CreateDefaultBuilder()
{
    return Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(app =>
        {
            app.AddJsonFile("appsettings.json");
        });
}







