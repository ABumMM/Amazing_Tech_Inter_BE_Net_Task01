using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.IServices;

namespace XuongMay.Services.CServices
{
    public class ProductService : IProductService
    {
        private readonly IProductReponsity _productReponsity;
        public ProductService(IProductReponsity productReponsity)
        {
            _productReponsity = productReponsity;
        }
        public async Task<ApiResponse> CreateAsync(ProductRequest request)
        {
            var product = new Product
            {
                IdProduct = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Detail =  request.Detail,
                CreateAt = DateTime.UtcNow
            };
            await _productReponsity.AddAsync(product);
            return new ApiResponse { Success = true, Message = "Product created successfully" };

        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var product = await _productReponsity.GetByIdAsync(id);
            if (product == null)
            {
                return new ApiResponse { Success = false, Message = "Product not found" };
            }

            await _productReponsity.DeleteAsync(product);
            return new ApiResponse { Success = true, Message = "Product deleted successfully" };
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var product = await _productReponsity.GetAllAsync();
            var productResponses = product.Select(p => new ProductResponse
            {
                IdProduct = p.IdProduct,
                Name = p.Name,
                CreateAt = p.CreateAt,
            }).ToList();
            return new ApiResponse { Success = true, Data = productResponses };
        }

        public async Task<ApiResponse> GetByIdAsync(Guid id)
        {
            var product = await _productReponsity.GetByIdAsync(id);
            return product != null
                ? new ApiResponse { Success = true, Data = product }
                : new ApiResponse { Success = false, Message = "Product not found" };
        }

        public async Task<ApiResponse> UpdateAsync(Guid id, ProductRequest request)
        {
            var product = await _productReponsity.GetByIdAsync(id);
            if (product == null)
                return new ApiResponse { Success = false, Message = "Product not found" };
            product.IdProduct = id;
            product.Name = request.Name;
            product.Price = request.Price;
            await _productReponsity.UpdateAsync(product);
            return new ApiResponse { Success = true, Message = "Product update succesful" };
        }
    }
}
