using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay.Dtos.Requests;
using XuongMay.Services.IServices;

namespace XuongMay.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // lấy tất cả thể loại
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return Ok(response);
        }

        // tạo thể loại
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request)
        {
            var response = await _categoryService.CreateAsync(request);
            return Ok(response);
        }

        // lấy thể loại theo id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return Ok(response);
        }

        // sửa thể loại theo id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryRequest request)
        {
            var response = await _categoryService.UpdateAsync(id, request);
            return Ok(response);
        }

        // xóa thể loại theo id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return Ok(response);
        }
    }
} 