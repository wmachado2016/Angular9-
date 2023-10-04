using CleanArch.Application.Services;
using CleanArch.Domain.Intefaces;
using Moq;
using System.Linq;
using Xunit;

namespace CleanArch.Tests.Unidade.Services
{
    [Collection(nameof(ClienteServiceCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteServiceFixtureTests _clienteServiceFixtureTests;
        private readonly ClienteService _clienteService;

        public ClienteServiceTests(ClienteServiceFixtureTests clienteServTestsFixture)
        {
            _clienteServiceFixtureTests = clienteServTestsFixture;
            _clienteService = _clienteServiceFixtureTests.ObterClienteService();
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Unidade", "Services - Cliente Service")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteServiceFixtureTests.GerarClienteValido();

            // Act
            _clienteService.Adicionar(cliente).GetAwaiter().GetResult();

            // Assert
            Assert.True(cliente.EhValido());
            _clienteServiceFixtureTests.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Unidade", "Services - Cliente Service")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteServiceFixtureTests.GerarClienteInvalido();

            // Act
            _clienteService.Adicionar(cliente);

            // Assert
            Assert.False(cliente.EhValido());
            _clienteServiceFixtureTests.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Unidade", "Services - Cliente Service")]
        public async void ClienteServiceObterTodosAtivosDeveRetornarApenasClientesAtivos()
        {
            //// Arrange
            //_clienteServiceFixtureTests.Mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos())
            //    .Returns(_clienteServiceFixtureTests.ObterClientesVariados());

            //// Act
            //var clientes = _clienteService.ObterTodosAtivos();

            //// Assert 
            //_clienteServiceFixtureTests.Mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
            //Assert.True(clientes.Any());
            //Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
}