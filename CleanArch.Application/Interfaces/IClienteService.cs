using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Cliente produto);
        Task Atualizar(Cliente produto);
        Task<IEnumerable<Cliente>> ObterTodosAtivos();
        Task Remover(Guid id);
    }
}