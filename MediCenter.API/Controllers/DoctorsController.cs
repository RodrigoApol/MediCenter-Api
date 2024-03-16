using MediatR;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;
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
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateDoctorCommand command)
    {
        var doctorId = await _mediator.Send(command);
        
        return Created();
    }
}