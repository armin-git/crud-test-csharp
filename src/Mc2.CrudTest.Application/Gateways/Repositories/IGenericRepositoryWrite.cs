namespace Mc2.CrudTest.Application.Gateways.Repositories;

using Domain.Base;

public interface IGenericRepositoryWrite<TEntity, in TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    Task<TEntity> GetByIdAsync(TPrimaryKey id);

    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    void UpdateAsync(TEntity entity);

    void DeleteAsync(TEntity entity);
    Task DeleteByIdAsync(TPrimaryKey id);
}