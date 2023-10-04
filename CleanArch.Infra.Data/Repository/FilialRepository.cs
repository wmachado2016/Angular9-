using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class FilialRepository : RepositoryBase<Filial>, IFilialRepository
    {
        public FilialRepository(MeuDbContext db) : base(db)
        {
        }
    }
}
