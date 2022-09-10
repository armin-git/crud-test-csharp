namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using Domain.Commons;
using Domain.Enums;
using MediatR;

public class EditCustomerCommand : IRequest<EditCustomerDto>
{
    public int Id { get; init; }
    
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public string BankAccountNumber { get; init; }
}

public class EditCustomerDto:ApplicationDto
{
    public bool Updated { get; set; }

    public EditCustomerDto(Status status, string message = null) : base(status, message)
    {
    }
}