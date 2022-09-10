namespace Mc2.CrudTest.Application.Gateways.Repositories;

using Microsoft.EntityFrameworkCore;
using Domain.Base;

public abstract class GenericRepositoryRead<TEntity, TPrimaryKey> : IGenericRepositoryRead<TEntity, TPrimaryKey>
    where TEntity : Entity<TPrimaryKey>
{
    protected readonly DbSet<TEntity> Entity;

    protected GenericRepositoryRead(DbContext context)
    {
        Entity = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Entity.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
    {
        return await Entity.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TPrimaryKey> ids)
    {
        return await Entity.Where(p => ids.Contains(p.Id)).ToListAsync();
    }
}