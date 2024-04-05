using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.MedicalService;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.DeleteMedicalService;

public class DeleteMedicalServiceCommandHandler(IMedicalServiceRepository repository)
    : IRequestHandler<DeleteMedicalServiceCommand, Result>
{
    private readonly IMedicalServiceRepository _repository = repository;

    public async Task<Result> Handle(DeleteMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var medicalService = await _repository.GetByIdAsync(request.Id);

        if (medicalService is null)
        {
            return Result.Fail(MedicalServiceErrors.NotFound(request.Id));
        }

        medicalService.DeleteService();
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}