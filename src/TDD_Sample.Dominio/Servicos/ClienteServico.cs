using System;
using System.Threading.Tasks;
using TDD_Sample.Dominio.Entidades;

namespace TDD_Sample.Dominio.Servicos
{
    public class ClienteServico: IClienteServico
    {
        public Task<Cliente> RegistrarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
