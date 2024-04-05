using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.MedicalService;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.UpdateService;

public class UpdateServiceCommandHandler(IServiceRepository repository) : IRequestHandler<UpdateServiceCommand, Result>
{
    private readonly IServiceRepository _repository = repository;
    
    public async Task<Result> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service is null)
        {
            return Result.Fail(MedicalServiceErrors.NotFound(request.Id));
        }
        
        service.UpdateService(request.Name, request.Description, request.Value, request.Duration);

        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}