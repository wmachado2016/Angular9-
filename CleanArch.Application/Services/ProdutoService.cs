using CleanArch.Application.Intefaces;
using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Domain.Models.Validations;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IUnitOfWork _uof;

        public ProdutoService(IUnitOfWork uof,INotificador notificador) : base(notificador)
        {
            _uof = uof;
        }

        public async Task<int> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return 0;

            await _uof.ProdutoRepository.Adicionar(produto);
            return await _uof.Commit();
        }

        public async Task<int> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return 0;

            await _uof.ProdutoRepository.Atualizar(produto);
            return await _uof.Commit();
        }

        public async Task<int> Remover(Guid id)
        {
            await _uof.ProdutoRepository.Remover(id);
            return await _uof.Commit();
        }

        public void Dispose()
        {
            _uof.ProdutoRepository?.Dispose();
        }
    }
}