using System;

namespace TDD_Sample.Api.Models
{
    public class ClienteReponse
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
