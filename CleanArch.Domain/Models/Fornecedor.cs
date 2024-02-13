using CleanArch.Domain.Models.Enumeradores;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Models
{
    public sealed class Fornecedor : Entidade
    {
        public Fornecedor(string nome, string documento, TipoPessoa tipoFornecedor, Endereco endereco, bool ativo, TipoDocumento tipoDocumento)
        {
            Nome = nome;
            Documento = documento;
            TipoPessoa = tipoFornecedor;
            Endereco = endereco;
            Ativo = ativo;
            TipoDocumento = tipoDocumento;
        }

        public Fornecedor()
        {

        }
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public bool Ativo { get; private set; }


        /* EF Relations */
        public Endereco Endereco { get;  set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}