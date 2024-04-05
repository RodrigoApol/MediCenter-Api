using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Patient;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.UpdatePatient;

public class UpdatePatientCommandHandler(IPatientRepository repository) : IRequestHandler<UpdatePatientCommand, Result>
{
    private readonly IPatientRepository _repository = repository;
    
    public async Task<Result> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
        {
            return Result.Fail(PatientErrors.NotFoundWithId(request.Id));
        }
        
        patient.UpdateUserData(
            request.Name, 
            request.Surname,
            request.BirthDate,
            request.Phone,
            request.Email,
            request.Cpf,
            request.BloodType,
            request.Weight,
            request.Height);

        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}