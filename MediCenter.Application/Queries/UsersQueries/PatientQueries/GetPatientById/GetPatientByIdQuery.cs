using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientById;

public record GetPatientByIdQuery(Guid Id) : IRequest<Result<PatientViewModel>>;