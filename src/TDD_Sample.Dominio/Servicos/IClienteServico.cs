using System.Threading.Tasks;
using TDD_Sample.Dominio.Entidades;

namespace TDD_Sample.Dominio.Servicos
{
    public interface IClienteServico
    {
        Task<Cliente> RegistrarAsync(Cliente cliente);
    }
}
