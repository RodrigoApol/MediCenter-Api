using AutoMapper;
using MediCenter.Application.Commands.ServicesCommands.ServiceCommand.CreateService;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Application.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<CreateServiceCommand, Service>();

        CreateMap<Service, ServiceViewModel>();
    }
}