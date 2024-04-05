using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByCpf;

public record GetPatientByCpfQuery(string Cpf) : IRequest<Result<PatientViewModel>>;