using AulaWebDev.Dominio.Entidades;

namespace AulaWebDev.Dominio.Repositorios
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
        Task<Category?> FindByIdAsync(Guid id);
        Task<ICollection<Category>> FindAllAsync();
    }
}
