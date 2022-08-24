using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Dominio.Validacoes;
using AutoMapper;

namespace AulaWebDev.Aplicacao.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDto>> CreateAsync(CategoryDto CategoryDto)
        {
            if (CategoryDto == null)
                return ResultService.Fail<CategoryDto>("Objeto nao pode ser nullo");

            var result = await new CategoryDtoValidator().ValidateAsync(CategoryDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Um ou mais erros foram encontrados", result);

            var persistedCategory = await _categoryRepository.CreateAsync(_mapper.Map<Category>(CategoryDto));
            var CategoryDtoPersistido = _mapper.Map<CategoryDto>(persistedCategory);

            return ResultService.Ok(CategoryDtoPersistido);
        }

        public async Task<ResultService> DeleteAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return ResultService.Fail<CategoryDto>("O category id deve ser informado");

            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category == null)
                return ResultService.Fail("Categoria não encontrada");

            if (await _categoryRepository.DeleteAsync(category))
                return ResultService.Ok("Categoria removida com sucesso");

            return ResultService.Fail("Ocorreu um erro ao remover a Categoria");
        }

        public async Task<ResultService> UpdateAsync(CategoryDto CategoryDto)
        {
            if (CategoryDto.Id == Guid.Empty)
                return ResultService.Fail<CategoryDto>("ID precisa ser informado");

            var result = await new CategoryDtoValidator().ValidateAsync(CategoryDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Um ou mais erros foram encontrados", result);

            var category = await _categoryRepository.FindByIdAsync(CategoryDto.Id);
            if (category == null)
                return ResultService.Fail("Categoria nao encontrado");

            //Mapeando propriedades informadas para edição, na entidade ja existente no banco!
            var categoryUpdated = _mapper.Map(CategoryDto, category);

            if (await _categoryRepository.UpdateAsync(categoryUpdated))
                return ResultService.Ok("Categoria atualizada com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar a Categoria");
        }

        public async Task<ResultService> FindByIdAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
                return ResultService.Fail<CategoryDto>("O category id deve ser informado");

            var category = await _categoryRepository.FindByIdAsync(categoryId);
            if (category == null)
                return ResultService.Fail<CategoryDto>("Categoria não encontrada");

            var CategoryDto = _mapper.Map<CategoryDto>(category);
            return ResultService.Ok(CategoryDto);
        }

        public async Task<ResultService<ICollection<CategoryDto>>> FindAllAsync()
        {
            var categories = await _categoryRepository.FindAllAsync();
            var categoriesMapped = _mapper.Map<ICollection<CategoryDto>>(categories);
            return ResultService.Ok(categoriesMapped);
        }
    }
}
