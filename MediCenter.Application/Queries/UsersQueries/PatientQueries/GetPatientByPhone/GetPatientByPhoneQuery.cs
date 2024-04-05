using System.ComponentModel.DataAnnotations;
using MediatR;
using MediCenter.Application.Errors;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Queries.UsersQueries.PatientQueries.GetPatientByPhone;

public record GetPatientByPhoneQuery(string Phone) : IRequest<Result<PatientViewModel>>;