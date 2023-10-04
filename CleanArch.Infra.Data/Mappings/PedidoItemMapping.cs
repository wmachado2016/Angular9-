using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.ProdutoNome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.ValorUnitario)
               .HasPrecision(10, 2);

            // 1 : N => Pedido : Pagamento
            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.PedidoItems);

            builder.HasQueryFilter(p => p.Ativo == true);

            builder.ToTable("PedidoItems");
        }
    }
}