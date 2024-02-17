using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
    {
        public AgendaRepository(AppDbContext db) : base(db)
        {
        }
    }
}
