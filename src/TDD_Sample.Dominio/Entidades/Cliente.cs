using System;


namespace TDD_Sample.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Cliente() { }

        public Cliente(string nome, string cpf, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public bool EstaValido()
        {
            if (string.IsNullOrWhiteSpace(Nome)) return false;
            if (string.IsNullOrWhiteSpace(Cpf)) return false;
            if (string.IsNullOrWhiteSpace(Email)) return false;
            if (DateTime.MinValue == DataNascimento) return false;

            return true;
        }
    }
}
