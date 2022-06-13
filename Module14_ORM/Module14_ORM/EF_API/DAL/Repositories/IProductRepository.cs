using Models;

namespace EF_API.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<List<Product>> GetProductsByName(string name);
        Task Create(Product entity);
        Task Update(Product entity);
        Task Delete(int id);
    }
}
