using AutoMapper;
using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetAllDoctors;

public class GetAllDoctorsQueryHandler(IDoctorRepository repository, IMapper mapper) : IRequestHandler<GetAllDoctorsQuery, List<DoctorViewModel>>
{
    private readonly IDoctorRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<List<DoctorViewModel>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _repository.GetAllAsync();

        var doctorsViewModel = _mapper.Map<List<DoctorViewModel>>(doctors);

        return doctorsViewModel;
    }
}