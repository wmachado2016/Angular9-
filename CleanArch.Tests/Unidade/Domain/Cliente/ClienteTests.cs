using Xunit;

namespace CleanArch.Tests.Unidade.Domain
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTests
    {
        private readonly ClienteFixtureTests _clienteTestsFixture;

        public ClienteTests(ClienteFixtureTests clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }


        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Unidade", "Domain - Cliente")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteValido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Equal(0, cliente.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Unidade", "Domain - Cliente")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _clienteTestsFixture.GerarClienteInvalido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}
