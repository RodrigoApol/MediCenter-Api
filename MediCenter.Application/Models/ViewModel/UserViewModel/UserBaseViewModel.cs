namespace MediCenter.Application.Models.ViewModel.UserViewModel;

public abstract record UserBaseViewModel
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}