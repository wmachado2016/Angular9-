using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria cat);
        Task Atualizar(Categoria cat);
        Task Remover(Guid id);
    }
}