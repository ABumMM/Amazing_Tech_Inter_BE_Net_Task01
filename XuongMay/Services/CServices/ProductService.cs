using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Entity;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.IServices;

namespace XuongMay.Services.CServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse?> CreateProductAsync(ProductRequest request)
        {
            var product = new Product
            {
                IdProduct = Guid.NewGuid(),
                Name = request.Name,
                Detail = request.Detail,
                Quantity = request.Quantity,
                Price = request.Price,
                Type = request.Type,
                IdUser = request.IdUser,
                IdCategory = request.IdCategory,
                CreateAt = DateTime.UtcNow
            };

            await _productRepository.AddProductAsync(product);

            return new ProductResponse
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Detail = product.Detail,
                Quantity = product.Quantity,
                Price = product.Price,
                Type = product.Type,
                IdUser = product.IdUser,
                IdCategory = product.IdCategory
            };
        }

        public async Task<ProductResponse?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return null;

            return new ProductResponse
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Detail = product.Detail,
                Quantity = product.Quantity,
                Price = product.Price,
                Type = product.Type,
                IdUser = product.IdUser,
                IdCategory = product.IdCategory
            };
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(product => new ProductResponse
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Detail = product.Detail,
                Quantity = product.Quantity,
                Price = product.Price,
                Type = product.Type,
                IdUser = product.IdUser,
                IdCategory = product.IdCategory
            });
        }

        public async Task<bool> UpdateProductAsync(Guid id, ProductRequest request)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return false;

            product.Name = request.Name;
            product.Detail = request.Detail;
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            product.Type = request.Type;
            product.IdUser = request.IdUser;
            product.IdCategory = request.IdCategory;

            await _productRepository.UpdateProductAsync(product);
            return true;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteProductAsync(product);
            return true;
        }
    }
}
