using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Dtos.Responses;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // tạo sản phẩm
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request);
            return CreatedAtAction(nameof(GetProductById), new { id = response?.IdProduct }, response);
        }

        // tìm sản phẩm theo id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            if (response == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sản phẩm không tìm thấy."
                });
            }

            return Ok(response);
        }

        // lấy tất cả sản phẩm
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(response);
        }

        // sửa sản phẩm theo id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductRequest request)
        {
            var success = await _productService.UpdateProductAsync(id, request);
            if (!success)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sản phẩm không tìm thấy."
                });
            }

            return NoContent();
        }

        // xóa sản phẩm theo id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var success = await _productService.DeleteProductAsync(id);
            if (!success)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sản phẩm không tìm thấy."
                });
            }

            return NoContent();
        }
    }
}
