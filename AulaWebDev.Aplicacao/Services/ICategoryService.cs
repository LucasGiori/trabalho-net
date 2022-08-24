using AulaWebDev.Dominio.DTOs;

namespace AulaWebDev.Aplicacao.Services
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResultService> UpdateAsync(CategoryDto categoryDto);
        Task<ResultService> DeleteAsync(Guid categoryId);
        Task<ResultService> FindByIdAsync(Guid categoryId);
        Task<ResultService<ICollection<CategoryDto>>> FindAllAsync();
    }
}
