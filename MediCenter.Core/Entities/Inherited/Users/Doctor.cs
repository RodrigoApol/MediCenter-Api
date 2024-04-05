using MediCenter.Core.Entities.Base;
using MediCenter.Core.Entities.ValueObjects;
using MediCenter.Core.Enums;

namespace MediCenter.Core.Entities.Inherited;

public class Doctor : UserBase
{
    protected Doctor() {}
    public Doctor(
        string name,
        string surname,
        DateTime birthDate,
        string phone,
        string email,
        string cpf,
        BloodTypeEnum bloodType,
        Address address,
        string specialty,
        string crm) : base(name, surname, birthDate, phone, email, cpf, bloodType, address)
    {
        Specialty = specialty;
        Crm = crm;
    }

    public string Specialty { get; private set; }
    public string Crm { get; private set; }

    public void UpdateUserData(string name, string surname, DateTime birthDate, string phone, string email, string cpf,
        BloodTypeEnum bloodType, string specialty, string crm)
    {
        base.UpdateUserData(name, surname, birthDate, phone, email, cpf, bloodType);
        Specialty = specialty;
        Crm = crm;
    }
}