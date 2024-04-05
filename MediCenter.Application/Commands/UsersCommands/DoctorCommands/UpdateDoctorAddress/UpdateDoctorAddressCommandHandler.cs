using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.UpdateDoctorAddress;

public class UpdateDoctorAddressCommandHandler(IDoctorRepository repository) : IRequestHandler<UpdateDoctorAddressCommand, Result>
{
    private readonly IDoctorRepository _repository = repository;
    
    public async Task<Result> Handle(UpdateDoctorAddressCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
        {
            return Result.Fail(DoctorErrors.NotFound(request.Id));
        }
        
        doctor.UpdateAddress(request.Address);
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}