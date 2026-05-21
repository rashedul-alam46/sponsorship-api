using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sponsorship.Interfaces.Helpers;


namespace Sponsorship.Infrastructure.Models;

public class MasterUnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public MasterUnitOfWork(DbContext context)
    {
        _context = context;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync()
        => _context.Database.BeginTransactionAsync();

    public Task<int> SaveChangesAsync()
        => _context.SaveChangesAsync();

    public Task ExecuteInTransactionAsync(Func<Task> action)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await action();
            await transaction.CommitAsync();
        });
    }

    public Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        return strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var result = await action();
            await transaction.CommitAsync();
            return result;
        });
    }
}
