using AutoMapper;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Errors.Service;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Repositories.ServicesRepositories;

namespace MediCenter.Application.Queries.ServicesQueries.ServiceQueries.GetServiceById;

public class GetServiceByIdQueryHandler(IServiceRepository repository, IMapper mapper) : IRequestHandler<GetServiceByIdQuery, Result<ServiceViewModel>>
{
    private readonly IServiceRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<Result<ServiceViewModel>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.Id);

        if (service is null)
        {
            return Result<ServiceViewModel>.Fail(ServiceErrors.NotFound(request.Id));
        }

        var serviceViewModel = _mapper.Map<ServiceViewModel>(service);

        return Result<ServiceViewModel>.Success(serviceViewModel);
    }
}