using Bogus;
using Bogus.Extensions.Brazil;
using Common.Testes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD_Sample.Api.Controllers;
using TDD_Sample.Api.Models;
using TDD_Sample.Dados.Repositorios;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Servicos;
using Xunit;

namespace TDD_Sample.Api.Testes.Controllers
{
    [Trait("Controllers", "ClienteController")]
    public class ClienteControllerTestes
    {
        private ClienteController _controller;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IClienteServico> _clienteServico;

        public ClienteControllerTestes()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _clienteServico = new Mock<IClienteServico>();
            _controller = new ClienteController(_unitOfWork.Object,_clienteServico.Object);
        }

        [Fact]
        public async void DeveRetornar_StatusCodeCreated()
        {
            //Arrange
            

            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            _clienteServico.Setup(x => x.RegistrarAsync(It.IsAny<Cliente>()))
                .ReturnsAsync(new ClienteFaker());

            //Act
            var result = await _controller.Post(new ClienteRequestFaker());
            

            //Assert
            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async void DeveRetornar_StatusCodeBadRequest()
        {
            //Arrange


            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(0);

            _clienteServico.Setup(x => x.RegistrarAsync(It.IsAny<Cliente>()))
                .ReturnsAsync(new ClienteFaker());

            //Act
            var result = await _controller.Post(new ClienteRequestFaker());


            //Assert
            result.Should().BeOfType<BadRequestResult>();
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

}
