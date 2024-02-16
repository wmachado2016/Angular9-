using CleanArch.Domain.Intefaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using DevIO.Data.Repository;
using System;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _dbContextSqlServer;
        private IProdutoRepository _produtoRepository;
        private IFornecedorRepository _fornecedorRepository;
        private IEnderecoRepository _enderecoRepository;
        private ICategoriaRepository _categoriaRepository;
        private IClienteRepository _clienteRepository;
        private IEstoqueMovimentadoRepository _estoqueMovimentadoRepository;
        private IFilialRepository _filialRepository;
        private IPedidoRepository _pedidoRepository;
        private IAgendaRepository _agendaRepository;
        private IServicoAgendaRepository _servicoAgendaRepository;
        public UnitOfWork(AppDbContext dbContextSqlServer)
        {
            _dbContextSqlServer = dbContextSqlServer;
        }

        public IFornecedorRepository FornecedorRepository =>  _fornecedorRepository ?? new FornecedorRepository(_dbContextSqlServer);

        public IProdutoRepository ProdutoRepository => _produtoRepository ?? new ProdutoRepository(_dbContextSqlServer);

        public ICategoriaRepository CategoriaRepository => _categoriaRepository ?? new CategoriaRepository(_dbContextSqlServer);

        public IEnderecoRepository EnderecoRepository => _enderecoRepository ?? new EnderecoRepository(_dbContextSqlServer);

        public IClienteRepository ClienteRepository => _clienteRepository ?? new ClienteRepository(_dbContextSqlServer);

        public IEstoqueMovimentadoRepository EstoqueMovimentadoRepository => _estoqueMovimentadoRepository ?? new EstoqueMovimentadoRepository(_dbContextSqlServer);

        public IFilialRepository FilialRepository => _filialRepository ?? new FilialRepository(_dbContextSqlServer);

        public IPedidoRepository PedidoRepository => _pedidoRepository ?? new PedidoRepository(_dbContextSqlServer);

        public IAgendaRepository AgendaRepository => _agendaRepository ?? new AgendaRepository(_dbContextSqlServer);

        public IServicoAgendaRepository ServicoAgendaRepository => _servicoAgendaRepository ?? new ServicoAgendaRepository(_dbContextSqlServer);

        public async Task<int> Commit()
        {
            return await _dbContextSqlServer.Commit();
        }

        public void Dispose()
        {
            _dbContextSqlServer.Dispose();
        }
    }
}
