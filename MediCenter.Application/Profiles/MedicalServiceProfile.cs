using AutoMapper;
using MediCenter.Application.Commands.ServicesCommands.MedicalServiceCommands.CreateMedicalService;
using MediCenter.Application.Models.ViewModel.ServicesViewModel;
using MediCenter.Core.Entities.Inherited.Services;

namespace MediCenter.Application.Profiles;

public class MedicalServiceProfile : Profile
{
    public MedicalServiceProfile()
    {
        CreateMap<CreateMedicalServiceCommand, MedicalService>();
        
        CreateMap<MedicalService, MedicalServiceViewModel>()
            .ForMember(dm => dm.ServiceName,
                op
                    => op.MapFrom(ms => ms.Service.Name))
            .ForMember(dm => dm.DoctorFullName,
                op
                    => op.MapFrom(ms => ms.Doctor.Name + "" + ms.Doctor.Surname))
            .ForMember(dm => dm.PatientFullName,
                op
                    => op.MapFrom(ms => ms.Patient.Name + "" + ms.Patient.Surname))
            .ForMember(dm => dm.StartedAt,
                op
                    => op.MapFrom(ms => ms.StartedAt.ToString("dd/MM/yyyy")))
            .ForMember(dm => dm.FinishAt,
                op
                    => op.MapFrom(ms => ms.FinishAt.ToString("dd/MM/yyyy")));
    }
}