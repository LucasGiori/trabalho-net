using AulaWebDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AulaWebDev.Infra.Mapeamentos
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Descricao)
                .HasColumnName("Description")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(c => c.Produtos)
              .WithOne(c => c.Category)
              .HasForeignKey(c => c.CategoriaId);
        }

    }
}
