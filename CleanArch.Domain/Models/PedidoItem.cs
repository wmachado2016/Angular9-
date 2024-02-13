using CleanArch.Domain.Models.Enumeradores;
using System;

namespace CleanArch.Domain.Models
{
    public class PedidoItem : Entidade
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public TipoPedido TipoPedido { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public bool Ativo { get; private set; }

        // EF Rel.
        public Pedido Pedido { get; set; }

        protected PedidoItem() { }

        public PedidoItem(Guid pedidoId, Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario, bool ativo)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId; 
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Ativo = ativo;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}