using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;

namespace MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetMedicalServiceById;

public record GetMedicalServiceByIdQuery(Guid Id) : IRequest<Result<MedicalServiceViewModel>>;