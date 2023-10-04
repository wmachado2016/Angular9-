using System;

namespace CleanArch.Domain.Models
{
    public class EstoqueMovimentado : Entity
    {
        public EstoqueMovimentado(Guid pordutoId, Guid pedidoId, double quantidade, decimal valor, char entrouSaiu)
        {
            CodigoProduto = pordutoId;
            CodigoPedido = pedidoId;
            Quantidade = quantidade;
            Valor = valor;
            EntrouSaiu = entrouSaiu;
        }
        public EstoqueMovimentado()
        {

        }

        public Guid CodigoProduto { get; private set; }
        public Guid CodigoPedido { get; private set; }
        public double Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public char EntrouSaiu { get; private set; }
    }
}
