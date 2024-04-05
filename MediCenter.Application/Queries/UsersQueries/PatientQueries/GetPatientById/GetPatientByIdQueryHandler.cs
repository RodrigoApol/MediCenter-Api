using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Patient;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientById;

public class GetPatientByIdQueryHandler(IPatientRepository repository, IMapper mapper) : IRequestHandler<GetPatientByIdQuery, Result<PatientViewModel>>
{
    private readonly IPatientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<PatientViewModel>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);

        if (patient is null)
        {
            return Result<PatientViewModel>.Fail(PatientErrors.NotFoundWithId(request.Id));
        }
        
        var patientViewModel = _mapper.Map<PatientViewModel>(patient);

        return Result<PatientViewModel>.Success(patientViewModel);
    }
}