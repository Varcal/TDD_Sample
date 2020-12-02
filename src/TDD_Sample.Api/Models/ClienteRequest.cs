using System;
using System.ComponentModel.DataAnnotations;


namespace TDD_Sample.Api.Models
{
    public class ClienteRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
