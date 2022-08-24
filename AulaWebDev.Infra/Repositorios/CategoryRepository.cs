using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<ClienteRepository> _logger;

        public CategoryRepository(AulaWebDevDbContext dbContext, ILogger<ClienteRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                _dbContext.Add(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return category;
            }
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            try
            {
                _dbContext.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                _dbContext.Update(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Category?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Category>> FindAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
