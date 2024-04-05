namespace MediCenter.Application.Models.ViewModel.ServicesViewModel;

public record ServiceViewModel(
    string Name,
    string Description,
    decimal Value,
    int Duration);