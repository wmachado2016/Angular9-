using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entidade
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);       
    }
}