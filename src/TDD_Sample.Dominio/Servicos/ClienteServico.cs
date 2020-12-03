using System.Threading.Tasks;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Repositorios;

namespace TDD_Sample.Dominio.Servicos
{
    public class ClienteServico: IClienteServico
    {
        private IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<Cliente> RegistrarAsync(Cliente cliente)
        {
            return await _clienteRepositorio.InserirAsync(cliente);
        }
    }
}
