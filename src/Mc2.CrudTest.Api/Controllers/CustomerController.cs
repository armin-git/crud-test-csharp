namespace Mc2.CrudTest.Api.Controllers;

using Application.Features.Customer.Queries;
using System;
using System.Threading.Tasks;
using ViewModel;
using Application.Features.Customer.Commands;
using Domain.Commons;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _mediator;

    public CustomerController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddCustomerViewModel customerViewModel)
    {
        return ObjectResult(await _mediator.Send(new AddCustomerCommand()
        {
            Firstname = customerViewModel.Firstname,
            Lastname = customerViewModel.Lastname,
            DateOfBirth = customerViewModel.DateOfBirth,
            PhoneNumber = customerViewModel.PhoneNumber,
            Email = customerViewModel.Email,
            BankAccountNumber = customerViewModel.BankAccountNumber,
        }));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return ObjectResult(await _mediator.Send(new GetCustomerByIdQuery()
        {
            Id = id
        }));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EditCustomerViewModel customerViewModel)
    {
        return ObjectResult(await _mediator.Send(new EditCustomerCommand()
        {
            Id = id,
            Firstname = customerViewModel.Firstname,
            Lastname = customerViewModel.Lastname,
            DateOfBirth = customerViewModel.DateOfBirth,
            PhoneNumber = customerViewModel.PhoneNumber,
            Email = customerViewModel.Email,
            BankAccountNumber = customerViewModel.BankAccountNumber,
        }));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return ObjectResult(await _mediator.Send(new DeleteCustomerCommand()
        {
            Id = id
        }));
    }

    private ObjectResult ObjectResult<T>(T dto) where T : ApplicationDto
    {
        object result = string.IsNullOrEmpty(dto.Message) ? dto : dto.Message;
        return StatusCode(GetStatus(dto.Status), result);
    }

    private static int GetStatus(Status status)
    {
        return status switch
        {
            Status.Ok => 200,
            Status.BadRequest => 400,
            Status.Forbidden => 403,
            Status.NotFound => 404,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}