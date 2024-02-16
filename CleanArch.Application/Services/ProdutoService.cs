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

        public int Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return 0;

             _uof.ProdutoRepository.Adicionar(produto);
            return  _uof.Commit().Result;
        }

        public int Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return 0;

             _uof.ProdutoRepository.Atualizar(produto);
            return  _uof.Commit().Result;
        }

        public int Remover(Guid id)
        {
             _uof.ProdutoRepository.Remover(id);
            return  _uof.Commit().Result;
        }

        public void Dispose()
        {
            _uof.ProdutoRepository?.Dispose();
        }
    }
}