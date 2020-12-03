using Common.Testes;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using TDD_Sample.Dados.Contexts;
using TDD_Sample.Dados.Repositorios;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Repositorios;
using Xunit;

namespace TDD_Sample.Dados.Testes
{
    [Trait("Repositorio", "Cliente")]
    public class ClienteRepositorioTestes
    {
        private readonly EfContext _efContext;
        private Mock<DbSet<Cliente>> _dbSet;
        private IClienteRepositorio _clienteRepositorio;

        public ClienteRepositorioTestes()
        {
            var options = new DbContextOptionsBuilder<EfContext>()
                .UseInMemoryDatabase(databaseName: "TDDSample_TestesDb")
                .Options;
            _efContext = new EfContext(options);
            _clienteRepositorio = new ClienteRepositorio(_efContext);
        }

        [Fact]
        public async void DeveInserirUmNovoCliente()
        {
          
            //Act
            var cliente = await _clienteRepositorio.InserirAsync(new ClienteFaker());

            //Assert
            cliente.Should().NotBeNull();
            cliente.Id.Should().BeGreaterThan(0);
        }
    }
}
