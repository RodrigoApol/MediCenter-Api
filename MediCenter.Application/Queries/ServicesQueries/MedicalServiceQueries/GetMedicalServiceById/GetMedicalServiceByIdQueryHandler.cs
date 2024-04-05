using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Doctor;
using MediCenter.Application.Errors.MedicalService;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetMedicalServiceById;

public class GetMedicalServiceByIdQueryHandler(IMedicalServiceRepository repository, IMapper mapper) : IRequestHandler<GetMedicalServiceByIdQuery, Result<MedicalServiceViewModel>>
{
    private readonly IMedicalServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<MedicalServiceViewModel>> Handle(GetMedicalServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalService = await _repository.GetByIdAsync(request.Id);

        if (medicalService is null)
        {
            return Result<MedicalServiceViewModel>.Fail(MedicalServiceErrors.NotFound(request.Id));
        }
        var medicalServiceViewModel = _mapper.Map<MedicalServiceViewModel>(medicalService);

        return Result<MedicalServiceViewModel>.Success(medicalServiceViewModel);
    }
}