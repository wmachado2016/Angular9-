using CleanArch.Application.Intefaces;
using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Domain.Models.Validations;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly IUnitOfWork _uof;

        public CategoriaService(INotificador notificador,IUnitOfWork uof) : base(notificador)
        {
            _uof = uof;
        }

        public void Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidacao(), categoria)) return;

             _uof.CategoriaRepository.Adicionar(categoria);
             _uof.Commit();
        }

        public void Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidacao(), categoria)) return;

             _uof.CategoriaRepository.Atualizar(categoria);
             _uof.Commit();
        }

        public void Remover(Guid id)
        {
             _uof.CategoriaRepository.Remover(id);
             _uof.Commit();
        }

        public void Dispose()
        {
            _uof.CategoriaRepository?.Dispose();
        }
    }
}