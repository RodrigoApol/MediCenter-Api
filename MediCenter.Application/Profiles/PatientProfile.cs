using AutoMapper;
using MediCenter.Application.Commands.UsersCommands.PatientCommands.CreatePatient;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Entities.Inherited;

namespace MediCenter.Application.Profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<CreatePatientCommand, Patient>();
        
        CreateMap<Patient, PatientViewModel>()
            .ForMember(e => e.BloodType, 
                op 
                    => op.MapFrom(p => p.BloodType.ToString()))
            .ForMember(e => e.BirthDate,
                op
                    => op.MapFrom(p => p.BirthDate.ToString("dd/MM/yyyy")));
    }
}