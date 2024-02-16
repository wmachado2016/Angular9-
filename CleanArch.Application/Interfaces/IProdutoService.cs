using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        int Adicionar(Produto produto);
        int Atualizar(Produto produto);
        int Remover(Guid id);
    }
}