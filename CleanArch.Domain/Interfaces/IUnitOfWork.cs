using CleanArch.Domain.Interfaces;
using System.Threading.Tasks;

namespace CleanArch.Domain.Intefaces
{
    public interface IUnitOfWork
    {
        IFornecedorRepository FornecedorRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository   CategoriaRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IEstoqueMovimentadoRepository EstoqueMovimentadoRepository { get; }
        IFilialRepository FilialRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IAgendaRepository AgendaRepository { get; }
        IServicoAgendaRepository ServicoAgendaRepository { get; }
        Task<int> Commit();
    }
}