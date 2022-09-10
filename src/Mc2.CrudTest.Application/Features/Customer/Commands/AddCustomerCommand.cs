using Mc2.CrudTest.Domain.Commons;
using Mc2.CrudTest.Domain.Enums;

namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using MediatR;

public class AddCustomerCommand : IRequest<AddCustomerDto>
{
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public string BankAccountNumber { get; init; }
}

public class AddCustomerDto:ApplicationDto
{
    public int Id { get; set; }

    public AddCustomerDto(Status status, string message = null) : base(status, message)
    {
    }
}