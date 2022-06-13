using Microsoft.EntityFrameworkCore;
using Models;
using Models.enums;

namespace EF_API.DAL.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task Create(Order entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order != null)
                 _context.Remove(order);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetById(int id)
        {
           var order = await _context.Orders.FindAsync(id);
           return order;
        }

        public async Task<Order> GetByStatus(Status status)
        {
            var order = await _context.Orders.Where(o => o.Status == status).FirstOrDefaultAsync();
            return order;
        }


        public async Task Update(Order entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

       
    }
}
