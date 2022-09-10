using Mc2.CrudTest.Application.Gateways.Repositories.Customer;

namespace Mc2.CrudTest.Infrastructure.Ef;

using Application.Gateways.Repositories;
using Persistence;
using Persistence.Repositories;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class StartupModules
{
    public static async Task<IServiceCollection> ConfigInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddScoped<ICustomerRepositoryRead, CustomerRepositoryRead>();
        services.AddScoped<ICustomerRepositoryWrite, CustomerRepositoryWrite>();
        
        // services.AddScoped<ApplicationDbContextRead, ApplicationDbContextRead>();
        // services.AddScoped<ApplicationDbContextWrite, ApplicationDbContextWrite>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationDbContextRead>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddDbContext<ApplicationDbContextWrite>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        await services.MigrateAsync<ApplicationDbContextWrite>(connectionString);
        
        return services;
    }
}