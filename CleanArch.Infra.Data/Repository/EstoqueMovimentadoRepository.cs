using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class EstoqueMovimentadoRepository : RepositoryBase<EstoqueMovimentado>, IEstoqueMovimentadoRepository
    {
        public EstoqueMovimentadoRepository(AppDbContext db) : base(db)
        {
        }
    }
}
