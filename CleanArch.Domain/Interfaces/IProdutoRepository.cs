using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}