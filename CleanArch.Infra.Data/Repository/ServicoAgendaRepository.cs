using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repository
{
    public class ServicoAgendaRepository : RepositoryBase<Servico>, IServicoAgendaRepository
    {
        public ServicoAgendaRepository(AppDbContext db) : base(db)
        {
        }
    }
}
