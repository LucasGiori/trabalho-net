using AulaWebDev.Aplicacao.Services;
using AulaWebDev.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebDev.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.FindAllAsync();
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{categoriaId}")]
        public async Task<IActionResult> GetAsync(Guid categoriaId)
        {
            var result = await _categoryService.FindByIdAsync(categoriaId);
            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateAsync(categoryDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{categoriaId}")]
        public async Task<IActionResult> PutAsync(Guid categoriaId, [FromBody] CategoryDto categoryDto)
        {
            categoryDto.Id = categoriaId;
            var result = await _categoryService.UpdateAsync(categoryDto);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{categoriaId}")]
        public async Task<IActionResult> DeleteAsync(Guid categoriaId)
        {
            var result = await _categoryService.DeleteAsync(categoriaId);

            if (result.Sucesso)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
