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

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidacao(), categoria)) return;

            await _uof.CategoriaRepository.Adicionar(categoria);
            await _uof.Commit();
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidacao(), categoria)) return;

            await _uof.CategoriaRepository.Atualizar(categoria);
            await _uof.Commit();
        }

        public async Task Remover(Guid id)
        {
            await _uof.CategoriaRepository.Remover(id);
            await _uof.Commit();
        }

        public void Dispose()
        {
            _uof.CategoriaRepository?.Dispose();
        }
    }
}