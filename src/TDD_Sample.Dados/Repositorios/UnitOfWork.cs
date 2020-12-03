
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using TDD_Sample.Dados.Contexts;

namespace TDD_Sample.Dados.Repositorios
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EfContext _efContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EfContext efContext)
        {
            _efContext = efContext;
           
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _efContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
           await _transaction.CommitAsync();
        }

        public async Task RollBackAsync()
        {
            await _transaction.RollbackAsync();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _efContext.SaveChangesAsync();
        }
    }
}
