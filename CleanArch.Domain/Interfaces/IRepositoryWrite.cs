using CleanArch.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
    }
}