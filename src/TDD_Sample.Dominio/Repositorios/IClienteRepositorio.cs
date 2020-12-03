using System.Threading.Tasks;
using TDD_Sample.Dominio.Entidades;

namespace TDD_Sample.Dominio.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<Cliente> InserirAsync(Cliente cliente);
    }
}
