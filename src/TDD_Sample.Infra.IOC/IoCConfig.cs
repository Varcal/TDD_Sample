using Microsoft.Extensions.DependencyInjection;
using TDD_Sample.Dados.Contexts;
using TDD_Sample.Dados.Repositorios;
using TDD_Sample.Dominio.Repositorios;
using TDD_Sample.Dominio.Servicos;

namespace TDD_Sample.Infra.IOC
{
    public static class IoCConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<EfContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteServico, ClienteServico>();
        }
    }
}
