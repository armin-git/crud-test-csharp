namespace Mc2.CrudTest.Application.Gateways.Repositories;

using Domain.Base;

public interface IGenericRepositoryRead<TEntity, in TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(TPrimaryKey id);
    Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TPrimaryKey> ids);
}