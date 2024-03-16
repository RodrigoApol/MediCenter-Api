using AutoMapper;
using MediCenter.Application.Commands.UsersCommands.DoctorCommands.CreateDoctor;
using MediCenter.Application.Models.ViewModel.UserViewModel;
using MediCenter.Core.Entities.Inherited;

namespace MediCenter.Application.Profiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>();

        CreateMap<Doctor, DoctorViewModel>()
            .ForMember(e => e.BloodType, 
                op 
                    => op.MapFrom(d => d.BloodType.ToString()));
    }
}