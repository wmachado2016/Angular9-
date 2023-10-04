
using CleanArch.Domain.Models;
using CleanArch.Domain.Validation;
using System;
using Xunit;

namespace CleanArch.Tests.Unidade.Domain

{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {

            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", "imagem", 100, true, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("nome", string.Empty, "imagem", 100, true, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("nome", "Descricao", "imagem", 0, true, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo Valor do produto não pode se menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Produto(string.Empty, "Descricao", "imagem", 100, true, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", string.Empty, 100, true, new Dimensoes(1, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao", "imagem", 100, true, new Dimensoes(0, 1, 1), Guid.NewGuid())
            );

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
