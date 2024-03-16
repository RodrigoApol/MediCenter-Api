using MediCenter.Core.Entities.Base;
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
    }
    
    public double Weight { get; private set; }
    public double Height { get; private set; }
}