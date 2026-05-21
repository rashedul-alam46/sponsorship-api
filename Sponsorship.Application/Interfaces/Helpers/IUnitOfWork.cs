using Microsoft.EntityFrameworkCore.Storage;

namespace Sponsorship.Interfaces.Helpers;

public interface IUnitOfWork
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task<int> SaveChangesAsync();
    Task ExecuteInTransactionAsync(Func<Task> action);
    Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action);
}

