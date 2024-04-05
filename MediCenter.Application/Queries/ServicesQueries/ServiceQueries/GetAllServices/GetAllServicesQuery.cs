using MediatR;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;

namespace MediCenter.Application.Queries.ServicesQueries.ServiceQuery.GetAllServices;

public class GetAllServicesQuery : IRequest<List<ServiceViewModel>>;
