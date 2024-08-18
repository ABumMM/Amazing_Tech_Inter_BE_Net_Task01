using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IProductService
    {
        Task<ApiResponse> GetByIdAsync(Guid id);
        Task<ApiResponse> CreateAsync(ProductRequest request);
        Task<ApiResponse> UpdateAsync(Guid id, ProductRequest request);
        Task<ApiResponse> DeleteAsync(Guid id);
        Task<ApiResponse> GetAllAsync();
    }
}
