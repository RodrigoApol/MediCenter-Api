using AutoMapper;
using MediatR;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;

public class CreateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper) : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<Doctor>(request);

        await _repository.AddAsync(doctor);
        await _repository.SaveChangesAsync();

        return doctor.Id;
    }
}