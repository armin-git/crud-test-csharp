using Mc2.CrudTest.Application.Gateways.Repositories;
using Mc2.CrudTest.Application.Gateways.Repositories.Customer;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.Ef.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Ef.Persistence.Repositories;

public class CustomerRepositoryWrite : GenericRepositoryWrite<Customer, int>, ICustomerRepositoryWrite
{
    public CustomerRepositoryWrite(ApplicationDbContextWrite context) : base(context)
    {
    }
}