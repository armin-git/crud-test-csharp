namespace Mc2.CrudTest.Domain.Exceptions;

public class PropertyBadFormatException<TEntity> : Exception
{
    public PropertyBadFormatException(string property) :
        base($"object {nameof(TEntity)} > {property} has BAD FORMAT")
    {
    }
}