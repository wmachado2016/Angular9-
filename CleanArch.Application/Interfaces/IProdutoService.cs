using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Task<int> Adicionar(Produto produto);
        Task<int> Atualizar(Produto produto);
        Task<int> Remover(Guid id);
    }
}