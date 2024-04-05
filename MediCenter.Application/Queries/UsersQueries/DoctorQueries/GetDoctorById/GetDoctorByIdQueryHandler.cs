using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Repositories.UsersRepositories;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetDoctorById;

public class GetDoctorByIdQueryHandler(IDoctorRepository repository, IMapper mapper) : IRequestHandler<GetDoctorByIdQuery, Result<DoctorViewModel>>
{
    private readonly IDoctorRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<DoctorViewModel>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);

        if (doctor is null)
        {
            return Result<DoctorViewModel>.Fail(DoctorErrors.NotFound(request.Id));
        }
        
        var doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);

        return Result<DoctorViewModel>.Success(doctorViewModel);
    }
}