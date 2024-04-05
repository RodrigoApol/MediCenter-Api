using MediatR;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.DeleteDoctor;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctor;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctorAddress;
using MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetAllDoctors;
using MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetDoctorById;
using MediCenter.Core.Entities.Inherited;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediCenter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllDoctorsQuery();

        var doctors = await _mediator.Send(query);

        return Ok(doctors);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetDoctorByIdQuery(id);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }  
    
    [HttpPost("create-doctor")]
    public async Task<IActionResult> Post(CreateDoctorCommand command)
    {
        var doctorId = await _mediator.Send(command);
        
        return CreatedAtAction(
            nameof(GetById),
            new {id = doctorId},
            command);
    }

    [HttpPut("update-doctor")]
    public async Task<IActionResult> Put(UpdateDoctorCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }

    [HttpPut("update-doctor-address")]
    public async Task<IActionResult> PutAddress(UpdateDoctorAddressCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    [HttpDelete("delete-doctor/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDoctorCommand(id);

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }
}