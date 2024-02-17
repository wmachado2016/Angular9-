using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IClienteService : IDisposable
    {
        void Adicionar(Cliente produto);
        void Atualizar(Cliente produto);
        Task<IEnumerable<Cliente>> ObterTodosAtivos();
        void Remover(Guid id);
    }
}