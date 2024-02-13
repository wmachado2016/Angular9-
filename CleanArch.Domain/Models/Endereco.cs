using CleanArch.Domain.Validation;
using System;

namespace CleanArch.Domain.Models
{
    public sealed class Endereco : Entidade
    {
        public Endereco(string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;

            Validar();
        }

        public Guid FornecedorId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid FilialId { get; set; }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public bool Ativo { get; set; }

        /* EF Relation */
        public Fornecedor Fornecedor { get; set; }
        public Cliente Cliente { get; set; }
        public Filial Filial { get; set; }

        public Endereco()
        {

        }
        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
            FornecedorId = fornecedor.Id;
        }

        public void AlterarCliente(Cliente cliente)
        {
            Cliente = cliente;
            ClienteId = cliente.Id;
        }

        public void AlterarFilial(Filial filial)
        {
            Filial = filial;
            FilialId = filial.Id;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Logradouro, "O campo Logradouro não pode estar vazio");
            Validacoes.ValidarSeVazio(Numero, "O campo Numero não pode estar vazio");
            Validacoes.ValidarSeVazio(Cep, "O campo Cep não pode estar vazio");
            Validacoes.ValidarSeVazio(Bairro, "O campo Bairro não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Cidade, "O campo Cidade não pode estar vazio");
            Validacoes.ValidarSeVazio(Estado, "O campo Estado não pode estar vazio");
        }
    }
}