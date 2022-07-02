
using DAL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<ProductEntity>
    {
        private protected ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductEntity> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public ProductEntity Get(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }

        public ProductEntity Get(string name)
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.ProductName == name);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }

        public void Create(ProductEntity product)
        {
            _dbContext.Products.Add(product);
        }

        public bool Delete(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                return false;
            }

            _dbContext.Remove(product);

            return true;
        }

        public void Update(ProductEntity product)
        {
            if (product.ProductID > 0)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
            }
        }
    }
}
