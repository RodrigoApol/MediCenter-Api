using AutoMapper;
using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetAllPatients;

public class GetAllPatientsQueryHandler(IPatientRepository repository, IMapper mapper) : IRequestHandler<GetAllPatientsQuery, List<PatientViewModel>>
{
    private readonly IPatientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<List<PatientViewModel>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repository.GetAllAsync();

        var patientsViewModel = _mapper.Map<List<PatientViewModel>>(patients);

        return patientsViewModel;
    }
}