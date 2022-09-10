namespace Mc2.CrudTest.Application.Gateways.Services;

using Domain.Entities;


public interface ICustomerServices
{
    Task IsEmailUnique(string email);
    Task IsCustomerUnique(Customer customer);
}