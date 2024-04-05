using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.MedicalService;
using MediCenter.Core.Repositories.ServicesRepositories;
using MediCenter.Infrastructure.Persistence.Repositories;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.UpdateMedicalService;

public class UpdateMedicalServiceCommandHandler(IMedicalServiceRepository repository) : IRequestHandler<UpdateMedicalServiceCommand, Result>
{
    private readonly IMedicalServiceRepository _repository = repository;
    
    public async Task<Result> Handle(UpdateMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var medicalService = await _repository.GetByIdAsync(request.Id);

        if (medicalService is null)
        {
            return Result.Fail(MedicalServiceErrors.NotFound(request.Id));
        }
        
        medicalService.UpdateMedicalService(request.StartedAt, request.FinishAt);
        await _repository.SaveChangesAsync();

        return Result.Success();
    }
}