using AutoMapper;
using MediatR;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Queries.ServicesQueries.ServiceQuery.GetAllServices;

public class GetAllServicesQueryHandler(IServiceRepository repository, IMapper mapper)
    : IRequestHandler<GetAllServicesQuery, List<ServiceViewModel>>
{
    private readonly IServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ServiceViewModel>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetAllAsync();

        var servicesViewModel = _mapper.Map<List<ServiceViewModel>>(services);

        return servicesViewModel;
    }
}