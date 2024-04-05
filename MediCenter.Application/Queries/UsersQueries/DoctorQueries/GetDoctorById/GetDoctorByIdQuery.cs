using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetDoctorById;

public record GetDoctorByIdQuery(Guid Id) : IRequest<Result<DoctorViewModel>>;