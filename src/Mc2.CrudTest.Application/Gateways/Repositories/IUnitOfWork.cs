namespace Mc2.CrudTest.Application.Gateways.Repositories;

using Customer;

public interface IUnitOfWork:IDisposable
{
    ICustomerRepositoryRead CustomerRepositoryRead { get; }
    ICustomerRepositoryWrite CustomerRepositoryWrite { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollBackTransactionAsync();
    Task<int> SaveChangesAsync();
}