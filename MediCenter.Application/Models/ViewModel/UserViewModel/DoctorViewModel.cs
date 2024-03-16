namespace MediCenter.Application.Models.ViewModel.UserViewModel;

public record DoctorViewModel(
    string Name,
    string Surname, 
    string BirthDate,
    string Phone,
    string Email,
    string Cpf,
    string BloodType,
    string Address,
    string Specialty,
    string Crm);