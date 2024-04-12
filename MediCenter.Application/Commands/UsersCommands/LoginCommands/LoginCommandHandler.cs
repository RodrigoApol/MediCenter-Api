using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Application.Errors.Login;
using MediCenter.Application.Models.ViewModel;
using MediCenter.Core.Entities.Base;
using MediCenter.Core.Repositories.UsersRepositories;
using MediCenter.Core.Services;

namespace MediCenter.Application.Commands.UsersCommands.LoginCommands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;

    public LoginCommandHandler(IAuthService authService, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
    {
        _authService = authService;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
    }
    
    public async Task<Result<LoginViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        UserBase? user;
        
        // var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        user = await _doctorRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);
        
        if (user is null)
        {
            user = await _patientRepository.GetByEmailAndPasswordAsync(request.Email, request.Password);
            
            if (user == null)
            {
                return Result<LoginViewModel>.Fail(LoginError.NotFound(request.Email));
            }
        }

        var token = _authService.GenerateJwtToken(user);

        var loginViewModel = new LoginViewModel(token);

        return Result<LoginViewModel>.Success(loginViewModel);
    }
}