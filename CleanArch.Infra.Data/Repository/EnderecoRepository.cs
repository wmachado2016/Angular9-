using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoCliente(Guid fornecedorId)
        {
            return await _dbContextSqlServer.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}