using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;

namespace XuongMay.Services.IServices
{
    public interface IProductService
    {
        Task<ProductResponse?> CreateProductAsync(ProductRequest request);
        Task<ProductResponse?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(Guid id, ProductRequest request);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
