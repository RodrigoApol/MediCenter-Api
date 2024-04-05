using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.DeleteDoctor;

public class DeleteDoctorCommandHandler(IDoctorRepository repository) : IRequestHandler<DeleteDoctorCommand, Result>
{
    private readonly IDoctorRepository _repository = repository;
    
    public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
        {
            return Result.Fail(DoctorErrors.NotFound(request.Id));
        }
        
        doctor.DeleteUser();
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}