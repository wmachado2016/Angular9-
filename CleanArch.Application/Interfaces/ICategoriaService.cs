using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface ICategoriaService : IDisposable
    {
        void Adicionar(Categoria cat);
        void Atualizar(Categoria cat);
        void Remover(Guid id);
    }
}