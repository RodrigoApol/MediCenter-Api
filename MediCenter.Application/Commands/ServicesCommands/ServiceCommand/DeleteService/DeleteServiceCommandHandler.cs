using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.MedicalService;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.DeleteService;

public class DeleteServiceCommandHandler(IServiceRepository repository) : IRequestHandler<DeleteServiceCommand, Result>
{
    private readonly IServiceRepository _repository = repository;
    
    public async Task<Result> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service is null)
        {
            return Result.Fail(MedicalServiceErrors.NotFound(request.Id));
        }
        
        service.DeleteService();
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}