using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;

namespace MediCenter.Application.Queries.ServicesQueries.ServiceQueries.GetServiceById;

public record GetServiceByIdQuery(Guid Id) : IRequest<Result<ServiceViewModel>>;