using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Conversores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id).HasName("PedidoItemId");


            builder.Property(c => c.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.ValorUnitario)
               .HasPrecision(10, 2);

            // 1 : N => Pedido : Pagamento
            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.PedidoItems);

            builder.Property(p => p.TipoPedido).HasColumnType("int")
                .HasConversion(new ConversorCustomizadoTipoPedido());

            builder.HasQueryFilter(p => p.Ativo == true);

            builder.ToTable("PedidoItems");
        }
    }
}