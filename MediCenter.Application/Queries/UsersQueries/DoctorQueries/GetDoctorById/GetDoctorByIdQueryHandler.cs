using AutoMapper;
using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetDoctorById;

public class GetDoctorByIdQueryHandler(IDoctorRepository repository, IMapper mapper) : IRequestHandler<GetDoctorByIdQuery, DoctorViewModel>
{
    private readonly IDoctorRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<DoctorViewModel> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        
        var doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);

        return doctorViewModel;
    }
}