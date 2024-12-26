using Microsoft.EntityFrameworkCore.Storage;
using Shopee.Infrastructure.Contexts;
using Shopee.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopeeDbContext _context;

    public UnitOfWork(ShopeeDbContext context)
    {
        _context = context;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}