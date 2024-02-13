using CleanArch.Domain.Validation;
using System;

namespace CleanArch.Domain.Models
{
    public sealed class Produto : Entidade
    {
        public Produto(string nome, string descricao, string imagem, decimal valor, bool ativo, Dimensoes dimensoes, Guid filialId)
        {
            Nome = nome;
            Descricao = descricao;
            Imagem = imagem;
            Valor = valor;
            Ativo = ativo;
            Dimensoes = dimensoes;
            FilialId = filialId;

            Validar();
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public decimal Valor { get; private set; }
        public double Estoque { get; private set; }
        public double EstoqueReservado { get; private set; }
        public string Unidade { get; private set; }
        public bool Ativo { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Guid FilialId { get; private set; }

        public Guid FornecedorId { get; set; }
        public Guid CategoriaId { get; set; }

        /* EF Relations */
        public Fornecedor Fornecedor { get; set; }
        public Categoria Categoria { get; set; }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public Produto() {}

        public void AdicionarEstoqueResevado(double qtde)
        {
            EstoqueReservado += qtde;
        }

        public void LimparEstoqueResevado()
        {
            EstoqueReservado = 0;
        }

        public double EstoqueDisponivel()
        {
            return Estoque - EstoqueReservado;
        }

        public void DebitarEstoque(double quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            Estoque -= quantidade;
        }

        public void ReporEstoque(double qtde)
        {
            Estoque += qtde;
        }

        public bool PossuiEstoque(double qtde)
        {
            return Estoque >= (qtde + EstoqueReservado);
        }
        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
            FornecedorId = fornecedor.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto não pode estar vazio");
            Descricao = descricao;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");            
        }
    }
}