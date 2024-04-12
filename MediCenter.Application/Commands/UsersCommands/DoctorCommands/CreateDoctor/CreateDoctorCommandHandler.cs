using AutoMapper;
using MediatR;
using MediCenter.Core.Entities.Inherited;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Core.Services;

namespace MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;

public class CreateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper, IAuthService authService) : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly IAuthService _authService = authService;
    
    public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<Doctor>(request);

        // var passwordHash = _authService.ComputeSha256Hash(doctor.Password);
        
        // doctor.PasswordSha256(passwordHash);
        
        await _repository.AddAsync(doctor);
        await _repository.SaveChangesAsync();

        return doctor.Id;
    }
}