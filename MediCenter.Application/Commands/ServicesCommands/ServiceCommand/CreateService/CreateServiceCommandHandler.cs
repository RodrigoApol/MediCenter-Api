using AutoMapper;
using MediatR;
using MediCenter.Core.Entities.Inherited.Services;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Commands.ServicesCommands.ServiceCommand.CreateService;

public class CreateServiceCommandHandler(IServiceRepository repository, IMapper mapper) : IRequestHandler<CreateServiceCommand, Guid>
{
    private readonly IServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request);

        await _repository.AddAsync(service);
        await _repository.SaveChangesAsync();

        return service.Id;
    }
}