using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Patient;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByPhone;

public class GetPatientByPhoneQueryHandler(IPatientRepository repository, IMapper mapper) :IRequestHandler<GetPatientByPhoneQuery, Result<PatientViewModel>>
{
    private readonly IPatientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<PatientViewModel>> Handle(GetPatientByPhoneQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByPhoneAsync(request.Phone);

        if (patient is null)
        {
            return Result<PatientViewModel>.Fail(PatientErrors.NotFoundWithPhone(request.Phone));
        }

        var patientViewModel = _mapper.Map<PatientViewModel>(patient);

        return Result<PatientViewModel>.Success(patientViewModel);
    }
}