using MediatR;
using MediCenter.Application.Commands.UsersCommands.Patient.CreatePatient;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;

public class CreatePatientCommandHandler(IPatientRepository repository) : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _repository = repository;

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Core.Entities.Inherited.Patient(
            request.Name,
            request.Surname,
            request.BirthDate,
            request.Phone,
            request.Email,
            request.Cpf,
            request.BloodType,
            request.Address,
            request.Weight,
            request.Height
            );

        await _repository.AddAsync(patient);
        await _repository.SaveChangesAsync();
        
        return patient.Id;
    }
}