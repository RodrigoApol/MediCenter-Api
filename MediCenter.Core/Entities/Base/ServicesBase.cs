namespace MediCenter.Core.Entities.Base;

public abstract class ServicesBase
{
    protected ServicesBase()
    {
        Id = new Guid();
    }

    public Guid Id { get; init; }
}