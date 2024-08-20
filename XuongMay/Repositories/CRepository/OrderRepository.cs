using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly XuongmaybeContext _context;

        public OrderRepository(XuongmaybeContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Order>().FindAsync(id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Set<Order>().ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Set<Order>().AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Set<Order>().Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
