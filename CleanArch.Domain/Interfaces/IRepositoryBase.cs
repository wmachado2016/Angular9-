using CleanArch.Domain.Models;

namespace CleanArch.Domain.Intefaces
{
    public interface IRepositoryBase<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entidade
    {
    }
}