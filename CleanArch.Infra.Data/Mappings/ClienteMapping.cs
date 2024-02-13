using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Conversores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : 1 => CLiente : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Cliente);

            builder.HasIndex(b => b.Documento);

            builder.Property(p => p.TipoDocumento).HasColumnType("int")
                .HasConversion(new ConversorCustomizadoTipoDocumento());

            builder.Property(p => p.TipoPessoa).HasColumnType("int")
                .HasConversion(new ConversorCustomizadoTipoPessoa());

            builder.ToTable("Clientes");

            //builder.HasQueryFilter(p => p.Ativo == true);
        }
    }
}