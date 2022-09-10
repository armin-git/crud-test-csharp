namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.Data;

using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContextRead : DbContext
{
    public ApplicationDbContextRead(DbContextOptions<ApplicationDbContextRead> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
    }
}