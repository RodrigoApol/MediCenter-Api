using MediatR;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;

namespace MediCenter.Application.Queries.ServicesQueries.MedicalServiceQueries.GetAllMedicalServices;

public class GetAllMedicalServicesQuery : IRequest<List<MedicalServiceViewModel>>
{
    
}