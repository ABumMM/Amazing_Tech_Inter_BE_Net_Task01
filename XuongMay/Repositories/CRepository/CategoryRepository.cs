using Microsoft.EntityFrameworkCore;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;

namespace XuongMay.Repositories.CRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly XuongmaybeContext _context; // readonly cho phép đảm bảo đối tượng này sẽ không bị thay đổi trong khi khởi tạo

        public CategoryRepository(XuongmaybeContext context) // nhận vào dữ liệu XuongmaybeContext, tạo xpng cái này rồi tạo ra cái trên
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id) // lấy đối tượng bảng Category trong dữ liệu bằng id 
        {
            return await _context.Set<Category>().FindAsync(id); // tìm và sẽ trả về id tương ứng
        }

        public async Task AddAsync(Category category)
        {
            await _context.Set<Category>().AddAsync(category); // thêm đối tượng mới vào bảng Category trong dữ liệu 
            await _context.SaveChangesAsync(); // Lưu lại
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Set<Category>().Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
