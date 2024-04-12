using MediatR;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.DeleteMedicalService;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.UpdateMedicalService;
using MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetAllMedicalServices;
using MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetMedicalServiceById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCenter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicalServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Policy = "Doctor")]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllMedicalServicesQuery();

        var medicalServices = await _mediator.Send(query);

        return Ok(medicalServices);
    }

    [Authorize(Policy = "Doctor")]
    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetMedicalServiceByIdQuery(id);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }

    [Authorize(Policy = "Doctor, Patient")]
    [HttpPost("create-medical-service")]
    public async Task<IActionResult> Post(CreateMedicalServiceCommand command)
    {
        var medicalServiceId = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new { id = medicalServiceId },
            command);
    }

    [Authorize(Policy = "Doctor")]
    [HttpPut("update-medical-service")]
    public async Task<IActionResult> Put(UpdateMedicalServiceCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }

    [Authorize(Policy = "Doctor")]
    [HttpDelete("delete-medical-service/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteMedicalServiceCommand(id);

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }
}