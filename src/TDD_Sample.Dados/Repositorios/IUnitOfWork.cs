using System.Threading.Tasks;

namespace TDD_Sample.Dados.Repositorios
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        Task<int> SaveChangesAsync();
    }
}
