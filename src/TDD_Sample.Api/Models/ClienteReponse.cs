using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
