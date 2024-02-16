using CleanArch.Application.Intefaces;
using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Models;
using CleanArch.Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IUnitOfWork _uof;

        public FornecedorService(INotificador notificador, IUnitOfWork uof) : base(notificador)
        {
            _uof = uof;
        }

        public int Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor) 
                || !ExecutarValidacao(new EnderecoValidacao(), fornecedor.Endereco)) return 0;

            if (_uof.FornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return 0;
            }

             _uof.FornecedorRepository.Adicionar(fornecedor);
            return  _uof.Commit().Result;
        }

        public int Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor)) return 0;

            if (_uof.FornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return 00 ;
            }

             _uof.FornecedorRepository.Atualizar(fornecedor);
            return  _uof.Commit().Result;
        }

        public int AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidacao(), endereco)) return 0;

             _uof.EnderecoRepository.Atualizar(endereco);
            return  _uof.Commit().Result;
        }

        public int Remover(Guid id)
        {
            if (_uof.FornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return 0;
            }

            var endereco =  _uof.EnderecoRepository.ObterEnderecoCliente(id).Result;

            if (endereco != null)
            {
                 _uof.EnderecoRepository.Remover(endereco.Id);
            }

             _uof.FornecedorRepository.Remover(id);
            return  _uof.Commit().Result;
        }

        public void Dispose()
        {
            _uof.FornecedorRepository?.Dispose();
            _uof.EnderecoRepository?.Dispose();
        }
    }
}