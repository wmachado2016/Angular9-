using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Conversores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            builder.HasIndex(b => b.Documento);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.Property(p => p.TipoDocumento)
                .HasConversion(new ConversorCustomizadoTipoDocumento());

            builder.Property(p => p.TipoPessoa)
                .HasConversion(new ConversorCustomizadoTipoPessoa());

            builder.ToTable("Fornecedores");

            builder.HasQueryFilter(p => p.Ativo == true);
        }
    }
}