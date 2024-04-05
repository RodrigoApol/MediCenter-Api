using MediCenter.Core.Entities.Base;
using MediCenter.Core.Entities.Inherited.Services;
using MediCenter.Core.Entities.ValueObjects;
using MediCenter.Core.Enums;

namespace MediCenter.Core.Entities.Inherited;

public class Patient : UserBase
{
    protected Patient() {}
    public Patient(
        string name, 
        string surname, 
        DateTime birthDate, 
        string phone, 
        string email, 
        string cpf, 
        BloodTypeEnum bloodType, 
        Address address,
        double weight,
        double height) : base(name, surname, birthDate, phone, email, cpf, bloodType, address)
    {
        Weight = weight;
        Height = height;
        MedicalServices = new List<MedicalService>();
    }
    
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public List<MedicalService> MedicalServices { get; set; }

    public void UpdateUserData(string name, string surname, DateTime birthDate, string phone, string email,
        string cpf, BloodTypeEnum bloodType, double weight, double height)
    {
        base.UpdateUserData(name, surname, birthDate, phone, email, cpf, bloodType);
        Weight = weight;
        Height = height;
    }
}