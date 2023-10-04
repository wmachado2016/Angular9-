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

        public async Task<int> Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor) 
                || !ExecutarValidacao(new EnderecoValidacao(), fornecedor.Endereco)) return 0;

            if (_uof.FornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return 0;
            }

            await _uof.FornecedorRepository.Adicionar(fornecedor);
            return await _uof.Commit();
        }

        public async Task<int> Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor)) return 0;

            if (_uof.FornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return 00 ;
            }

            await _uof.FornecedorRepository.Atualizar(fornecedor);
            return await _uof.Commit();
        }

        public async Task<int> AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidacao(), endereco)) return 0;

            await _uof.EnderecoRepository.Atualizar(endereco);
            return await _uof.Commit();
        }

        public async Task<int> Remover(Guid id)
        {
            if (_uof.FornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return 0;
            }

            var endereco = await _uof.EnderecoRepository.ObterEnderecoPorFornecedor(id);

            if (endereco != null)
            {
                await _uof.EnderecoRepository.Remover(endereco.Id);
            }

            await _uof.FornecedorRepository.Remover(id);
            return await _uof.Commit();
        }

        public void Dispose()
        {
            _uof.FornecedorRepository?.Dispose();
            _uof.EnderecoRepository?.Dispose();
        }
    }
}