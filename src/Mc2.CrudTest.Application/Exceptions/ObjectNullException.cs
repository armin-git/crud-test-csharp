namespace Mc2.CrudTest.Application.Exceptions;

public class ObjectNullException<TEntity> : Exception
{
    public ObjectNullException() :
        base($"object {typeof(TEntity).Name} in NULL")
    {
    }
}