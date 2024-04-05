namespace MediCenter.Core.Entities.Base;

public abstract class ServicesBase
{
    protected ServicesBase()
    {
        Id = new Guid();
        IsDeleted = false;
    }

    public Guid Id { get; init; }
    public bool IsDeleted { get; set; }

    public void DeleteService()
    {
        IsDeleted = true;
    }
}