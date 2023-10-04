using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<int> Adicionar(Fornecedor fornecedor);
        Task<int> Atualizar(Fornecedor fornecedor);
        Task<int> Remover(Guid id);

        Task<int> AtualizarEndereco(Endereco endereco);
    }
}