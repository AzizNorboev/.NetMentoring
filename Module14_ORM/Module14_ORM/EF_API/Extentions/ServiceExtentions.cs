using EF_API.DAL;
using EF_API.DAL.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EF_API.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(
               options => options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")
                   )
               );
        }
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
