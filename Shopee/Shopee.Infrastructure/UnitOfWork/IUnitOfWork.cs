using Microsoft.EntityFrameworkCore.Storage;

namespace Shopee.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
