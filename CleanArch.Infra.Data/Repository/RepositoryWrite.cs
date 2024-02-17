using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public abstract class RepositoryWrite<TEntity> : IRepositoryWrite<TEntity> where TEntity : Entidade, new()
    {
        protected readonly AppDbContext _dbContextSqlServer;

        protected RepositoryWrite(AppDbContext db)
        {
            _dbContextSqlServer = db;
        }
        
        public virtual void Adicionar(TEntity entity)
        {
            _dbContextSqlServer.Set<TEntity>().Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContextSqlServer.Set<TEntity>().Update(entity);
        }

        public virtual void Remover(Guid id)
        {
            _dbContextSqlServer.Set<TEntity>().Remove(new TEntity { Id = id });
        }

        public void Dispose()
        {
            _dbContextSqlServer?.Dispose();
        }
    }
}