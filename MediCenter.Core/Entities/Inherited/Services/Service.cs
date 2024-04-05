using MediCenter.Core.Entities.Base;

namespace MediCenter.Core.Entities.Inherited.Services;

public class Service : ServicesBase
{
    protected Service()
    {
        
    }
    
    public Service(string name, string description, decimal value, int duration)
    {
        Name = name;
        Description = description;
        Value = value;
        Duration = duration;
        MedicalServices = new List<MedicalService>();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public int Duration { get; private set; }
    public List<MedicalService> MedicalServices { get; set; }

    public void UpdateService(string name, string description, decimal value, int duration)
    {
        Name = name;
        Description = description;
        Value = value;
        Duration = duration;
    }
}