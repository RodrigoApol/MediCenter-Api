namespace MediCenter.Application.Models.ViewModel.UserViewModel;

public record PatientViewModel(
    string Weight,
    string Height
) : UserBaseViewModel;