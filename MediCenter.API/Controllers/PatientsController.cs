using MediatR;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.DeletePatient;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatient;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatientAddress;
using MediCenter.Application.Errors;
using MediCenter.Application.Queries.UsersQueries.PatientQueries.GetAllPatients;
using MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByCpf;
using MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientById;
using MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByPhone;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediCenter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPatientsQuery();

        var patients = await _mediator.Send(query);

        return Ok(patients);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetPatientByIdQuery(id);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
    
    [HttpGet("get-by-cpf/{cpf}")]
    public async Task<IActionResult> GetByCpf(string cpf)
    {
        var query = new GetPatientByCpfQuery(cpf);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpGet("get-by-phone/{phone}")]
    public async Task<IActionResult> GetByPhone(string phone)
    {
        var query = new GetPatientByPhoneQuery(phone);

        var result = await _mediator.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpPost("create-patient")]
    public async Task<IActionResult> Post(CreatePatientCommand command)
    {
        var idPatient = await _mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById),
            new {id = idPatient},
            command);
    }

    [HttpPut("update-patient")]
    public async Task<IActionResult> Put(UpdatePatientCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return NoContent();
    }

    [HttpPut("update-patient-address")]
    public async Task<IActionResult> PutAddress(UpdatePatientAddressCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }

    [HttpDelete("delete-patient/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeletePatientCommand(id);
        
        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return NoContent();
    }
}