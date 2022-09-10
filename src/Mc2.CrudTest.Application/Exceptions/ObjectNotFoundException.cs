namespace Mc2.CrudTest.Application.Exceptions;

public class ObjectNotFoundException<TEntity> : Exception
{
    public ObjectNotFoundException() :
        base($"object {typeof(TEntity).Name} Not Found")
    {
    }
}