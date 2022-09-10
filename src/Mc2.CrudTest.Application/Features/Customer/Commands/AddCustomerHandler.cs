using Mc2.CrudTest.Application.Gateways.Services;
using Mc2.CrudTest.Domain.Gateways.Request;

namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using Mc2.CrudTest.Application.Exceptions.Customer;
using Domain.Enums;
using Gateways.Repositories;
using Domain.Entities;
using MediatR;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, AddCustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerServices _customerServices;

    public AddCustomerHandler(IUnitOfWork unitOfWork, ICustomerServices customerServices)
    {
        _unitOfWork = unitOfWork;
        _customerServices = customerServices;
    }

    public async Task<AddCustomerDto> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = new(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber,
            request.Email, request.BankAccountNumber);

        await _customerServices.IsEmailUnique(customer.Email);
        await _customerServices.IsCustomerUnique(customer);

        await _unitOfWork.CustomerRepositoryWrite.AddAsync(customer);
        var result = await _unitOfWork.SaveChangesAsync();
        return new AddCustomerDto(result > 0 ? Status.Ok : Status.BadRequest) { Id = customer.Id };
    }

    
}