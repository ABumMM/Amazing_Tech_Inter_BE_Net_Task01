using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
    public class ProductResposity : IProductReponsity
    {
        private readonly XuongmaybeContext _context;

        public ProductResposity(XuongmaybeContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Set<Product>().Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }
    }
}
