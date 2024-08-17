using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.IServices;

namespace XuongMay.Services.CServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            // Map dữ liệu từ Category sang CategoryResponse
            var categoryResponses = categories.Select(c => new CategoryResponse
            {
                IdCategory = c.IdCategory,
                Slug = c.Slug,
                Name = c.Name,
                CreateAt = c.CreateAt
            }).ToList();

            return new ApiResponse { Success = true, Data = categoryResponses };
        }

        public async Task<ApiResponse> CreateAsync(CategoryRequest request)
        {
            var category = new Category
            {
                IdCategory = Guid.NewGuid(),
                Slug = request.Slug,
                Name = request.Name,
                CreateAt = DateTime.UtcNow
            };

            await _categoryRepository.AddAsync(category);
            return new ApiResponse { Success = true, Message = "Category created successfully" };
        }

        public async Task<ApiResponse> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null
                ? new ApiResponse { Success = true, Data = category }
                : new ApiResponse { Success = false, Message = "Category not found" };
        }

        public async Task<ApiResponse> UpdateAsync(Guid id, CategoryRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResponse { Success = false, Message = "Category not found" };

            category.Slug = request.Slug;
            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);
            return new ApiResponse { Success = true, Message = "Category updated successfully" };
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return new ApiResponse { Success = false, Message = "Category not found" };

            await _categoryRepository.DeleteAsync(category);
            return new ApiResponse { Success = true, Message = "Category deleted successfully" };
        }
    }
}
