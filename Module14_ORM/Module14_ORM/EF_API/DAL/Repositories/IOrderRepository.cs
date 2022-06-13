using Models;
using Models.enums;

namespace EF_API.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> GetByStatus(Status status);
        Task Create(Order entity);
        Task Update(Order entity);
        Task Delete(int id);
    }
}
