using MediatR;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetAllPatients;

public class GetAllPatientsQuery : IRequest<List<PatientViewModel>>;