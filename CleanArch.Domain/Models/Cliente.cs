using CleanArch.Domain.Models.Enumeradores;
using CleanArch.Domain.Models.Validations;
using System;
using System.Collections.Generic;

namespace CleanArch.Domain.Models
{
    public class Cliente : Entidade
    {
        
        public Cliente(string nome, string sobrenome, DateTime dataNascimento, string email, bool ativo, string documento, TipoPessoa tipoPessoa, TipoDocumento tipoDocumento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
            Ativo = ativo;
            Documento = documento;
            TipoPessoa = tipoPessoa;
            TipoDocumento = tipoDocumento;
        }

        public Cliente()
        {
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Documento { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public bool Ativo { get; private set; }

        public Endereco Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public bool EhEspecial()
        {
            return DataCadastro < DateTime.Now.AddYears(-3) && Ativo;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
