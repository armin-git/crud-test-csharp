namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using Domain.Commons;
using Domain.Enums;
using MediatR;

public class DeleteCustomerCommand:IRequest<DeleteCustomerDto>
{
    public int Id { get; init; }
}

public class DeleteCustomerDto:ApplicationDto
{
    public bool Deleted { get; set; }

    public DeleteCustomerDto(Status status, string message = null) : base(status, message)
    {
    }
}