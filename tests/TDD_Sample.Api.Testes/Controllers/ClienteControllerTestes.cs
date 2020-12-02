using System;
using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.TestHost;
using Moq;
using TDD_Sample.Api.Controllers;
using TDD_Sample.Api.Models;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Servicos;
using Xunit;

namespace TDD_Sample.Api.Testes.Controllers
{
    [Trait("Controllers", "ClienteController")]
    public class ClienteControllerTestes
    {
        private ClienteController _controller;
        private Mock<IClienteServico> _clienteServico;

        public ClienteControllerTestes()
        {
            _clienteServico = new Mock<IClienteServico>();
            _controller = new ClienteController(_clienteServico.Object);
        }

        [Fact]
        public async void DeveRetornar_StatusCodeCreated()
        {
            //Arrange
            var cliente = new ClienteFaker().Generate();
            _clienteServico.Setup(x => x.RegistrarAsync(It.IsAny<Cliente>()))
                .ReturnsAsync(cliente);

            //Act
            var result = await _controller.Post(new ClienteRequestFaker().Generate());
            

            //Assert
            result.Should().BeOfType<CreatedResult>();
        }
    }

    public class ClienteRequestFaker : Faker<ClienteRequest>
    {
        public ClienteRequestFaker()
        {
            RuleFor(c => c.Nome, f => f.Person.FullName);
            RuleFor(c => c.Cpf, f => f.Person.Cpf(false));
            RuleFor(c => c.Email, f => f.Person.Email);
            RuleFor(c => c.DataNascimento, f => f.Person.DateOfBirth);
        }
    }

    public class ClienteFaker : PrivateFaker<Cliente>
    {
        public ClienteFaker()
        {
            RuleFor(c => c.Nome, f => f.Person.FullName);
            RuleFor(c => c.Cpf, f => f.Person.Cpf(false));
            RuleFor(c => c.Email, f => f.Person.Email);
            RuleFor(c => c.DataNascimento, f => f.Person.DateOfBirth);
        }
    }

    public class PrivateFaker<T> : Faker<T> where T : class
    {
        public PrivateFaker<T> UsePrivateConstructor()
        {
            return base.CustomInstantiator(f => Activator.CreateInstance(typeof(T), nonPublic: true) as T)
                as PrivateFaker<T>;
        }

        public PrivateFaker<T> RuleForPrivate<TProperty>(string propertyName, Func<Faker, TProperty> setter)
        {
            base.RuleFor(propertyName, setter);
            return this;
        }
    }
}
