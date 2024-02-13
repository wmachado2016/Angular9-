using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(p => p.Id).HasName("CategoriaId");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(20)");

            // 1 : N => Categoria : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            builder.HasIndex(b => b.Nome);

            //builder.HasData(
            //    new Categoria("Eletrônicos", 1, true),
            //    new Categoria("Produtos de Beleza", 2, true),
            //    new Categoria("Acessórios Automotivos", 3, true),
            //    new Categoria("Acessórios Eletrônicos", 3, true)
            //    );

            builder.HasQueryFilter(p => p.Ativo == true);

            builder.ToTable("Categorias");
        }
    }
}