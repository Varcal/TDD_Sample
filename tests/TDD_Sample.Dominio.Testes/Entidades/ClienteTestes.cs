using System;
using Bogus;
using FluentAssertions;
using Xunit;
using Bogus.Extensions.Brazil;
using TDD_Sample.Dominio.Entidades;

namespace TDD_Sample.Dominio.Testes.Entidades
{
    [Trait("Entidades", "Cliente")]
    public class ClienteTestes
    {
        private readonly Faker _faker;

        public ClienteTestes()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public void DeveCriarClienteValido()
        {
            //Arrange
            var nome = _faker.Person.FullName;
            var cpf = _faker.Person.Cpf(false);
            var email = _faker.Person.Email;
            var dataNascimento = _faker.Person.DateOfBirth;

            //Act
            var cliente = new Cliente(nome, cpf, email, dataNascimento);
           
            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeTrue();
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveEstarInvalidoSeNomeNaoInformado(string nome)
        {
            //Arrange
            var cpf = _faker.Person.Cpf();
            var email = _faker.Person.Email;
            var dataNascimento = _faker.Person.DateOfBirth;

            //Act
            var cliente = new Cliente(nome, cpf, email, dataNascimento);

            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveEstarInvalidoSeCPFNaoInformado(string cpf)
        {
            //Arrange
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var dataNascimento = _faker.Person.DateOfBirth;

            //Act
            var cliente = new Cliente(nome, cpf, email, dataNascimento);

            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveEstarInvalidoSeEmailNaoInformado(string email)
        {
            //Arrange
            var nome = _faker.Person.FullName;
            var cpf = _faker.Person.Cpf(false);
            var dataNascimento = _faker.Person.DateOfBirth;

            //Act
            var cliente = new Cliente(nome, cpf, email, dataNascimento);

            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeFalse();
        }

        [Fact]
        public void DeveEstarInvalidoSeDataNascimentoNaoInformado()
        {
            //Arrange
            var nome = _faker.Person.FullName;
            var cpf = _faker.Person.Cpf(false);
            var email = _faker.Person.Email;
            var dataNascimento = DateTime.MinValue;

            //Act
            var cliente = new Cliente(nome, cpf, email, dataNascimento);

            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeFalse();
        }
    }
}
