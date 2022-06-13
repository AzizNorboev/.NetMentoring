using Microsoft.EntityFrameworkCore;
using Models;

namespace EF_API.DAL.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task Create(Product entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
                _context.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            var products = await _context.Products.Where(p => p.Name.Equals(name)).ToListAsync();
            return products;
        }

        public async Task Update(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
