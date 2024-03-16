using MediatR;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}