namespace Mc2.CrudTest.Application.Features.Customer.Queries;

using Domain.Commons;
using Domain.Enums;
using MediatR;

public class GetCustomerByIdQuery:IRequest<GetCustomerByIdDto>
{
    public int Id { get; init; }
}

public class GetCustomerByIdDto:ApplicationDto
{
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public string BankAccountNumber { get; init; }

    public GetCustomerByIdDto(Status status, string message = null) : base(status, message)
    {
    }
}