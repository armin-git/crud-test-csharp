using System.Data;
using Mc2.CrudTest.Application.Gateways.Repositories;
using Mc2.CrudTest.Application.Gateways.Repositories.Customer;
using Mc2.CrudTest.Infrastructure.Ef.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private bool _disposed;
    private IDbContextTransaction _dbContextTransaction;
    private readonly ApplicationDbContextRead _contextRead;
    private readonly ApplicationDbContextWrite _contextWrite;

    private readonly Lazy<ICustomerRepositoryRead> _customerRepositoryRead;
    private readonly Lazy<ICustomerRepositoryWrite> _customerRepositoryWrite;

    
    public UnitOfWork(ApplicationDbContextRead contextRead, ApplicationDbContextWrite contextWrite)
    {
        _contextRead = contextRead;
        _contextWrite = contextWrite;
        _customerRepositoryRead = new(() => new CustomerRepositoryRead(contextRead));
        _customerRepositoryWrite = new(() => new CustomerRepositoryWrite(contextWrite));
    }

    public ICustomerRepositoryRead CustomerRepositoryRead => _customerRepositoryRead.Value;
    public ICustomerRepositoryWrite CustomerRepositoryWrite => _customerRepositoryWrite.Value;

    
    public async Task BeginTransactionAsync()
    {
        _disposed = false;
        _dbContextTransaction = await _contextWrite.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContextTransaction.CommitAsync();
    }

    public async Task RollBackTransactionAsync()
    {
        await _dbContextTransaction.RollbackAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _contextWrite.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        //GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _contextRead?.Dispose();
            _contextWrite?.Dispose();
            _dbContextTransaction?.Dispose();
        }

        _disposed = true;
    }
}