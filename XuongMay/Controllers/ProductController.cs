using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            var response = await _productService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _productService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductRequest request)
        {
            var response = await _productService.UpdateAsync(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
