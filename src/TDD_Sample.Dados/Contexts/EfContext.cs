using Microsoft.EntityFrameworkCore;
using TDD_Sample.Dominio.Entidades;

namespace TDD_Sample.Dados.Contexts
{
    public class EfContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TDDSampleDb");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
