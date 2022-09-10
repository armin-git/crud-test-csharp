namespace Mc2.CrudTest.Infrastructure.Ef.Persistence;

public abstract class DbSchemaConfig<T> where T : class
{
    private const string Prefix = "Tbl_";

    private const string Suffix = "s";

    protected static readonly string TableName = typeof(T).Name + Suffix;

    public static string TableNameWithPrefix = Prefix + typeof(T).Name;
}

