using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using CleanArch.Application.Services;
using CleanArch.Domain.Models;
using CleanArch.Domain.Models.Enumeradores;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CleanArch.Tests.Unidade.Services
{
    [CollectionDefinition(nameof(ClienteServiceCollection))]
    public class ClienteServiceCollection : ICollectionFixture<ClienteServiceFixtureTests>
    { }

    public class ClienteServiceFixtureTests : IDisposable
    {

        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public Cliente GerarClienteValido()
        {
            return GerarClientes(1, true).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarClientes(50, true).ToList());
            clientes.AddRange(GerarClientes(50, false).ToList());

            return clientes;
        }

        public IEnumerable<Cliente> GerarClientes(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var clientes = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    f.Person.Cpf(),
                    TipoPessoa.Cliente,
                    TipoDocumento.CPF))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLower()));

            return clientes.Generate(quantidade);
        }

        public Cliente GerarClienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    false,
                    f.Person.Cpf(),
                    TipoPessoa.Cliente,
                    TipoDocumento.CPF));

            return cliente;
        }

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            ClienteService = Mocker.CreateInstance<ClienteService>();

            return ClienteService;
        }

        public void Dispose()
        {
        }
    }
}
