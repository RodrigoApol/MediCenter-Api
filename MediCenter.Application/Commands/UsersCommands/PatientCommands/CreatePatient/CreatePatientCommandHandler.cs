using AutoMapper;
using MediatR;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Core.Services;

namespace MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;

public class CreatePatientCommandHandler(IPatientRepository repository, IMapper mapper) : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly IPatientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = _mapper.Map<Patient>(request);
        
        await _repository.AddAsync(patient);
        await _repository.SaveChangesAsync();
        
        return patient.Id;
    }
}