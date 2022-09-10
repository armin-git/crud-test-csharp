using Mc2.CrudTest.Domain.Gateways.Request;

namespace Mc2.CrudTest.Application.Gateways.Repositories.Customer;

using Domain.Entities;

public interface ICustomerRepositoryRead : IGenericRepositoryRead<Customer, int>
{
    Task<bool> IsEmailUnique(string email);
    Task<bool> IsCustomerUnique(CustomerUnique customerUnique);
}