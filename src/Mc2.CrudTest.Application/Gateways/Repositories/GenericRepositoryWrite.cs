namespace Mc2.CrudTest.Application.Gateways.Repositories;

using Exceptions;
using Microsoft.EntityFrameworkCore;
using Domain.Base;

public abstract class GenericRepositoryWrite<TEntity, TPrimaryKey> : IGenericRepositoryWrite<TEntity, TPrimaryKey>
    where TEntity : Entity<TPrimaryKey>
{
    protected readonly DbContext Context;

    protected readonly DbSet<TEntity> Entity;

    protected GenericRepositoryWrite(DbContext context)
    {
        Context = context;
        Entity = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
    {
        return await Entity.FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await Entity.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Entity.AddRangeAsync(entities?? throw new ObjectNullException<TEntity>());
        return entities;
    }

    public void UpdateAsync(TEntity entity)
    {
        Entity.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
    }

    public void DeleteAsync(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(TPrimaryKey id)
    {
        Entity.Remove(await Entity.FindAsync(id) ?? throw new ObjectNotFoundException<TEntity>());
    }
}