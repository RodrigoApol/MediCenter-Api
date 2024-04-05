using AutoMapper;
using MediatR;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetAllMedicalServices;

public class GetAllMedicalServicesQueryHandler(IMedicalServiceRepository repository, IMapper mapper) : IRequestHandler<GetAllMedicalServicesQuery, List<MedicalServiceViewModel>>
{
    private readonly IMedicalServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<List<MedicalServiceViewModel>> Handle(GetAllMedicalServicesQuery request, CancellationToken cancellationToken)
    {
        var medicalServices = await _repository.GetAllAsync();

        var medicalServicesViewModel = _mapper.Map<List<MedicalServiceViewModel>>(medicalServices);

        return medicalServicesViewModel;
    }
}