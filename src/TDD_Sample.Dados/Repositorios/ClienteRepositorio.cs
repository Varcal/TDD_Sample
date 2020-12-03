using System.Threading.Tasks;
using TDD_Sample.Dados.Contexts;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Repositorios;

namespace TDD_Sample.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly EfContext _efContext;

        public ClienteRepositorio(EfContext efContext)
        {
            _efContext = efContext;
        }


        public async Task<Cliente> InserirAsync(Cliente cliente)
        {
            await _efContext.Clientes.AddAsync(cliente);

            return cliente;
        }
    }
}
