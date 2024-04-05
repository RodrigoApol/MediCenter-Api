using MediCenter.Core.Entities.ValueObjects;
using MediCenter.Core.Enums;

namespace MediCenter.Core.Entities.Base;

public abstract class UserBase
{
    protected UserBase()
    {
    }

    protected UserBase(string name, string surname, DateTime birthDate, string phone, string email, string cpf,
        BloodTypeEnum bloodType, Address address)
    {
        Id = new Guid();
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        Phone = phone;
        Email = email;
        Cpf = cpf;
        BloodType = bloodType;
        Address = address;
        IsDeleted = false;
    }

    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public BloodTypeEnum BloodType { get; private set; }
    public Address Address { get; private set; }
    public bool IsDeleted { get; private set; }

    protected void UpdateUserData(string name, string surname, DateTime birthDate, string phone, string email,
        string cpf, BloodTypeEnum bloodType)
    {
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        Phone = phone;
        Email = email;
        Cpf = cpf;
        BloodType = bloodType;
    }

    public void UpdateAddress(Address address)
    {
        Address = address;
    }

    public void DeleteUser()
    {
        IsDeleted = true;
    }
}