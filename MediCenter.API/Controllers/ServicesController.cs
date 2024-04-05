using MediatR;
using MediCenter.Application.Commands.ServicesCommands.ServiceCommand.CreateService;
using MediCenter.Application.Commands.ServicesCommands.ServiceCommand.DeleteService;
using MediCenter.Application.Commands.ServicesCommands.ServiceCommand.UpdateService;
using MediCenter.Application.Queries.ServicesQueries.ServiceQueries.GetServiceById;
using MediCenter.Application.Queries.ServicesQueries.ServiceQuery.GetAllServices;
using Microsoft.AspNetCore.Mvc;

namespace MediCenter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllServicesQuery();

        var services = await _mediator.Send(query);

        return Ok(services);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetServiceByIdQuery(id);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [HttpPost("create-service")]
    public async Task<IActionResult> Post(CreateServiceCommand commad)
    {
        var serviceId = await _mediator.Send(commad);

        return CreatedAtAction(
            nameof(GetById),
            new { id = serviceId },
            commad);
    }

    [HttpPut("update-service")]
    public async Task<IActionResult> Put(UpdateServiceCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }

    [HttpDelete("delete-service/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteServiceCommand(id);

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }
}