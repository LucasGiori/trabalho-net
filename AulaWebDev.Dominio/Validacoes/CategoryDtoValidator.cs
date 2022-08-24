using AulaWebDev.Dominio.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Validacoes
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            ValidarDescricao();
        }

        private void ValidarDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descricao deve ser informado");
        }

    }
}
