using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        private readonly StreamWriter _writer = new StreamWriter("log_ef_core.txt", append: true);

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filial> Filial { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        public async Task<int> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("CriadoPor").CurrentValue = "usuarioLogado";
                    entry.Property("ModificadoPor").CurrentValue = "usuarioLogado";
                    entry.Property("DataModificado").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("CriadoPor").IsModified = false;
                    entry.Property("DataModificado").IsModified = true;
                    entry.Property("ModificadoPor").IsModified = true;

                    entry.Property("ModificadoPor").CurrentValue = "usuarioLogado";
                    entry.Property("DataModificado").CurrentValue = DateTime.Now;
                }
            }


            return await base.SaveChangesAsync();
        }

        public override void Dispose()
        {
            base.Dispose();
            _writer.Dispose();
        }
    }    
}
