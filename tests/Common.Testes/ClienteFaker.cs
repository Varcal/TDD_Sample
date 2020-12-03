using Bogus.Extensions.Brazil;
using TDD_Sample.Dominio.Entidades;

namespace Common.Testes
{
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
}
