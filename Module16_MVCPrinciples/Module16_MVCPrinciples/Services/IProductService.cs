using Models;
using ReflectionIT.Mvc.Paging;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProductList();
        PagingList<Product> GetAll(int pageSize, int page);
        Product GetById(int id);
        Product GetByName(string name);
        void Create(Product product);
        void Update(Product product);
        bool Delete(int id);
    }
}
