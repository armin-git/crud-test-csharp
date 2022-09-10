using Mc2.CrudTest.Application.Gateways.Repositories;
using Mc2.CrudTest.Application.Gateways.Repositories.Customer;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Gateways.Request;
using Mc2.CrudTest.Infrastructure.Ef.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.Repositories;

public class CustomerRepositoryRead : GenericRepositoryRead<Customer, int>, ICustomerRepositoryRead
{
    public CustomerRepositoryRead(ApplicationDbContextRead context) : base(context)
    {
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return await Entity.AnyAsync(p => p.Email == email);
    }

    public async Task<bool> IsCustomerUnique(CustomerUnique customerUnique)
    {
        return await Entity.AnyAsync(p =>
            p.Firstname == customerUnique.Firstname &&
            p.Lastname == customerUnique.Lastname &&
            p.DateOfBirth == customerUnique.DateOfBirth);
    }
}