using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Conversores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.Mappings
{
    public class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(c => c.Id).HasName("AgendaId");            

            builder.HasQueryFilter(p => p.Ativo == true);
            builder.Property(p => p.TipoPessoa).HasColumnType("int").HasConversion(new ConversorCustomizadoTipoPessoa());
            
            builder.ToTable("Agendas");
        }
    }
}