using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Patient;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByCpf;

public class GetPatientByCpfQueryHandler(IPatientRepository repository, IMapper mapper) : IRequestHandler<GetPatientByCpfQuery, Result<PatientViewModel>>
{
    private readonly IPatientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<PatientViewModel>> Handle(GetPatientByCpfQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByCpfAsync(request.Cpf);

        if (patient is null)
        {
            return Result<PatientViewModel>.Fail(PatientErrors.NotFoundWithCpf(request.Cpf));
        }
        
        var patientViewModel = _mapper.Map<PatientViewModel>(patient);

        return Result<PatientViewModel>.Success(patientViewModel);
    }
}