namespace Mc2.CrudTest.Domain.Base;

public abstract class Entity<T> 
{
    public T Id { get; init; }
}