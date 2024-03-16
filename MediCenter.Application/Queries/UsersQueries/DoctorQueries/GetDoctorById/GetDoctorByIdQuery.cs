using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetDoctorById;

public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorViewModel>;