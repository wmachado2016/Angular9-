using CleanArch.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CleanArch.Application.Intefaces
{
    public interface IFornecedorService : IDisposable
    {
        int Adicionar(Fornecedor fornecedor);
        int Atualizar(Fornecedor fornecedor);
        int Remover(Guid id);

        int AtualizarEndereco(Endereco endereco);
    }
}