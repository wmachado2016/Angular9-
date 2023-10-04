using CleanArch.Domain.Models.Enumeradores;
using CleanArch.Domain.Models.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Models
{
    public class Voucher : Entity
    {
        public Voucher(string codigo, decimal? percentual, decimal? valorDesconto, int quantidade, TipoDescontoVoucher tipoDescontoVoucher, DateTime? dataUtilizacao, DateTime dataValidade, bool ativo, bool utilizado)
        {
            Codigo = codigo;
            Percentual = percentual;
            ValorDesconto = valorDesconto;
            Quantidade = quantidade;
            TipoDescontoVoucher = tipoDescontoVoucher;
            DataUtilizacao = dataUtilizacao;
            DataValidade = dataValidade;
            Ativo = ativo;
            Utilizado = utilizado;
        }

        public Voucher()
        {

        }
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        // EF Rel.
        public ICollection<Pedido> Pedidos { get; set; }

        internal ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidacao().Validate(this);
        }
    }
   
}