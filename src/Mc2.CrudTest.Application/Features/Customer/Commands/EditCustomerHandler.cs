using Mc2.CrudTest.Application.Gateways.Services;

namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using Mc2.CrudTest.Application.Exceptions.Customer;
using Mc2.CrudTest.Domain.Gateways.Request;
using Domain.Enums;
using Gateways.Repositories;
using Domain.Entities;
using MediatR;

public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, EditCustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerServices _customerServices;

    public EditCustomerHandler(IUnitOfWork unitOfWork, ICustomerServices customerServices)
    {
        _unitOfWork = unitOfWork;
        _customerServices = customerServices;
    }

    public async Task<EditCustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _unitOfWork.CustomerRepositoryWrite.GetByIdAsync(request.Id);

        if (request.Email != customer.Email)
            await _customerServices.IsEmailUnique(request.Email);

        customer.UpdateMinor(request.Firstname, request.Lastname, request.DateOfBirth);
        customer.UpdateMajor(request.PhoneNumber, request.Email, request.BankAccountNumber);
        
        await _customerServices.IsCustomerUnique(customer);

        var updated = await _unitOfWork.SaveChangesAsync();

        return new EditCustomerDto(updated > 0 ? Status.Ok : Status.BadRequest) { Updated = updated > 0 };
    }
}