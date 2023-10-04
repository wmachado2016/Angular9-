using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}