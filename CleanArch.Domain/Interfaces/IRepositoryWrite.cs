using CleanArch.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entidade
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(Guid id);
    }
}