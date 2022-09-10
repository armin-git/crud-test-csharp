namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.Data;

using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContextWrite : DbContext
{
    public ApplicationDbContextWrite(DbContextOptions<ApplicationDbContextWrite> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}