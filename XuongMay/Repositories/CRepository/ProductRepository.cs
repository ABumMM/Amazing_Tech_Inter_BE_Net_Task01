using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly XuongmaybeContext _context;

        public ProductRepository(XuongmaybeContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
