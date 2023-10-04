using CleanArch.Domain.Models.Enumeradores;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Models
{
    public class Filial : Entity
    {
        public Filial(string name, TipoPessoa tipoPessoa, bool ativo)
        {
            Name = name;
            Ativo = ativo;
            TipoPessoa = tipoPessoa;
        }
        public Filial()
        {

        }

        public string Name { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }
        public Endereco Endereco { get; set; }
    }
}
