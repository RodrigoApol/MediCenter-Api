using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.DoctorQueries.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<List<DoctorViewModel>>;