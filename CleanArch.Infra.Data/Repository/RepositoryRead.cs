using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public abstract class RepositoryRead<TEntity> : IRepositoryRead<TEntity> where TEntity : Entity
    {
        protected readonly MeuDbContext _dbContextSqlServer;

        protected RepositoryRead(MeuDbContext db)
        {
            _dbContextSqlServer = db;
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContextSqlServer.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbContextSqlServer.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _dbContextSqlServer.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _dbContextSqlServer?.Dispose();
        }
    }
}