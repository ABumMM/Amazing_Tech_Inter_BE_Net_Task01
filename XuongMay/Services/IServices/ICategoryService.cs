using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface ICategoryService
    {
        Task<ApiResponse> GetByIdAsync(Guid id);
        Task<ApiResponse> CreateAsync(CategoryRequest request);
        Task<ApiResponse> UpdateAsync(Guid id, CategoryRequest request);
        Task<ApiResponse> DeleteAsync(Guid id);
        Task<ApiResponse> GetAllAsync();
    }
}
