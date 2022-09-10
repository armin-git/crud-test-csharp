namespace Mc2.CrudTest.Domain.Exceptions;

public class PropertyNullException<TEntity> : Exception
{
    public PropertyNullException(string property) :
        base($"object {typeof(TEntity).Name} {property} in NULL")
    {
    }
}