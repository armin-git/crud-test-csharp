namespace Mc2.CrudTest.Application;


using Gateways.Services;
using services.Customer;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class StartupModules
{
    public static async Task<IServiceCollection> ConfigApplication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.AddScoped<ICustomerServices, CustomerServices>();
        
        return services;
    }
}