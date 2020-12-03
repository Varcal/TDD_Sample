using Common.Testes;
using FluentAssertions;
using Moq;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Repositorios;
using TDD_Sample.Dominio.Servicos;
using Xunit;

namespace TDD_Sample.Dominio.Testes.Servicos
{
    [Trait("Servico", "Cliente")]
    public class ClienteServicoTestes
    {
        private Mock<IClienteRepositorio> _clienteRepositorio;
        private IClienteServico _clienteServico;

        public ClienteServicoTestes()
        {
            _clienteRepositorio = new Mock<IClienteRepositorio>();
            _clienteServico = new ClienteServico(_clienteRepositorio.Object);
        }

        [Fact]
        public async void DeveRegistrarUmNovoUsuario()
        {
            //Arrange
            _clienteRepositorio.Setup(x => x.InserirAsync(It.IsAny<Cliente>()))
                .ReturnsAsync(new ClienteFaker());
            
            //Act
            var cliente = await _clienteServico.RegistrarAsync(new ClienteFaker());

            //Assert
            cliente.Should().NotBeNull();
            cliente.EstaValido().Should().BeTrue();
        }
    }
}
