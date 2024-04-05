using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Patient;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.DeletePatient;

public class DeletePatientCommandHandler(IPatientRepository repository) : IRequestHandler<DeletePatientCommand, Result>
{
    private readonly IPatientRepository _repository = repository;
    
    public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
        {
            return Result.Fail(PatientErrors.NotFoundWithId(request.Id));
        }
        
        patient.DeleteUser();
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}