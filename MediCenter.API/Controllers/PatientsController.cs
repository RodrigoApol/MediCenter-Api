using MediatR;
using MediCenter.Application.Commands.UsersCommands.Patient.CreatePatient;
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

    [HttpGet("{cpf}")]
    public IActionResult GetByCpf(string cpf)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreatePatientCommand command)
    {
        var idPatient = await _mediator.Send(command);

        return Created();
    }
}