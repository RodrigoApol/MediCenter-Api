using AutoMapper;
using MediatR;
using MediCenter.Core.Entities.Inherited.Services;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;

public class CreateMedicalServiceCommandHandler(IMedicalServiceRepository repository, IMapper mapper) : IRequestHandler<CreateMedicalServiceCommand, Guid>
{
    private readonly IMedicalServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Guid> Handle(CreateMedicalServiceCommand request, CancellationToken cancellationToken)
    {
        var medicalService = _mapper.Map<MedicalService>(request);

        await _repository.AddAsync(medicalService);
        await _repository.SaveChangesAsync();

        return medicalService.Id;
    }
}