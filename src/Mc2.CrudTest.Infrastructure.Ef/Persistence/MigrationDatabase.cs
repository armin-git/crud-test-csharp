namespace Mc2.CrudTest.Infrastructure.Ef.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


public static class MigrationDatabase
{
    public static async Task<IServiceCollection> MigrateAsync<TDbContext>(this IServiceCollection services,
        string connectionString) where TDbContext : DbContext
    {
        var logger = services.BuildServiceProvider().GetRequiredService<ILogger<TDbContext>>();
        try
        {
            await using var scope = services.BuildServiceProvider().CreateAsyncScope();
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
            applicationDbContext.Database.SetConnectionString(connectionString);

#if RELEASE
            var migrations = await applicationDbContext.Database.GetPendingMigrationsAsync();
            if (migrations.Any())
                await applicationDbContext.Database.MigrateAsync();
#else
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.Database.EnsureCreatedAsync();

#endif
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message, exception);
        }

        return services;
    }
}