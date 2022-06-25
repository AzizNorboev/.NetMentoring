using DAL.DTOs;

namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CategoryEntity> Categories { get; }
        IRepository<ProductEntity> Products { get; }
        void Save();
    }
}
