using CleanArch.Domain.Validation;
using System.Collections.Generic;

namespace CleanArch.Domain.Models
{
    public sealed class Categoria : Entidade
    {
        public Categoria(string nome, int codigo, bool ativo)
        {
            Nome = nome;
            Codigo = codigo;
            Ativo = ativo;

            Validar();
        }

        public Categoria()
        {

        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
