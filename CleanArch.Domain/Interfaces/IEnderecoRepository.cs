using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Task<Endereco> ObterEnderecoCliente(Guid clienteId);
    }
}