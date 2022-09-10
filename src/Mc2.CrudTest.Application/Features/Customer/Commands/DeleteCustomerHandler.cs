namespace Mc2.CrudTest.Application.Features.Customer.Commands;

using Domain.Enums;
using Gateways.Repositories;
using MediatR;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteCustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CustomerRepositoryWrite.DeleteByIdAsync(request.Id);
        var deleted = await _unitOfWork.SaveChangesAsync();
        return new DeleteCustomerDto(deleted > 0 ? Status.Ok : Status.BadRequest) { Deleted = deleted > 0 };
    }
}