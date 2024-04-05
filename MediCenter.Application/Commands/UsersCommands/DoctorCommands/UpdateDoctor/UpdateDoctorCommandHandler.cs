using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctor;

public class UpdateDoctorCommandHandler(IDoctorRepository repository) : IRequestHandler<UpdateDoctorCommand, Result>
{
    private readonly IDoctorRepository _repository = repository;
    
    public async Task<Result> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        
        if (doctor is null) 
            return Result.Fail(DoctorErrors.NotFound(request.Id));
        
        doctor.UpdateUserData(
            request.Name,
            request.Surname,
            request.BirthDate,
            request.Phone,
            request.Email,
            request.Cpf,
            request.BloodType,
            request.Specialty,
            request.Crm);

        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}