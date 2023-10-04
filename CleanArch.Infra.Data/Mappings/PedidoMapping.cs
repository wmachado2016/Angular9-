using CleanArch.Domain.Models;
using CleanArch.Domain.Models.Enumeradores;
using CleanArch.Infra.Data.Conversores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

            builder.Property(c => c.ValorTotal)
                .HasPrecision(10,2);

            builder.Property(c => c.Desconto)
                .HasPrecision(10, 2);

            builder.HasIndex(b => b.Codigo);

            // 1 : N => Pedido : PedidoItems
            builder.HasMany(c => c.PedidoItems)
                .WithOne(c => c.Pedido)
                .HasForeignKey(c => c.PedidoId);

            builder.Property(p => p.PedidoStatus)
                .HasConversion(new ConversorCustomizadoPedidoStatus());

            builder.HasQueryFilter(p => p.PedidoStatus != PedidoStatus.Cancelado);

            builder.ToTable("Pedidos");
        }
    }
}