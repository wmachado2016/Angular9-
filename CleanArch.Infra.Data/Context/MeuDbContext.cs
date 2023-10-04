using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        private readonly StreamWriter _writer = new StreamWriter("log_ef_core.txt", append: true);

        public MeuDbContext(DbContextOptions options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Filial> Filial { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(options =>
                    {
                        options.EnableRetryOnFailure();
                    })
                    .EnableSensitiveDataLogging()
                    .LogTo(_writer.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);

          
            base.OnModelCreating(modelBuilder);
        }

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
