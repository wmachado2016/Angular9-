using CleanArc.WebApi.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.WebApi.Identity.Data
{
    public class AppDbContextIdentity : IdentityDbContext
    {
        public AppDbContextIdentity(DbContextOptions<AppDbContextIdentity> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            var entityType = builder.Entity<AspNetUsers>();

            entityType.Property(u => u.TipoUsuario).HasColumnType("int"); ;
            entityType.Property(u => u.Imagem).HasColumnType("varbinary(max)");


            // Renomear as tabelas do Identity
            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UseRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
        }

    }
}