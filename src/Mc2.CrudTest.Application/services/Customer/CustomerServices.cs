namespace Mc2.CrudTest.Application.services.Customer;

using Gateways.Services;
using Mc2.CrudTest.Application.Exceptions.Customer;
using Gateways.Repositories;
using Mc2.CrudTest.Domain.Gateways.Request;
using Domain.Entities;

public class CustomerServices:ICustomerServices
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task IsEmailUnique(string email)
    {
        if (await _unitOfWork.CustomerRepositoryRead.IsEmailUnique(email))
            throw new CustomerEmailIsNotUnique(email);
    }

    public async Task IsCustomerUnique(Customer customer)
    {
        var customerUnique = new CustomerUnique()
        {
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            DateOfBirth = customer.DateOfBirth
        };

        if (await _unitOfWork.CustomerRepositoryRead.IsCustomerUnique(customerUnique))
            throw new CustomerEmailIsNotUnique(customer.Email);
    }
}