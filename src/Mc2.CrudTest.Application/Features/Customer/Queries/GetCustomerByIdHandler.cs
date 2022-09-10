namespace Mc2.CrudTest.Application.Features.Customer.Queries;

using Domain.Enums;
using Gateways.Repositories;
using Domain.Entities;
using MediatR;


public class GetCustomerByIdHandler:IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCustomerByIdDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer customer = await _unitOfWork.CustomerRepositoryRead.GetByIdAsync(request.Id);
        GetCustomerByIdDto getCustomerByIdDto = new(customer != null ? Status.Ok : Status.BadRequest)
        {
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            DateOfBirth = customer.DateOfBirth,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            BankAccountNumber = customer.BankAccountNumber
        };
        return getCustomerByIdDto;

    }
}