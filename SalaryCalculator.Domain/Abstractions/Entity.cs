namespace SalaryCalculator.Domain.Common;

public abstract class Entity<TEntityId>
{
    protected Entity(TEntityId id)
    {
        Id = id;
    }

#pragma warning disable CS8618
    protected Entity() //Dapper Access
    {
    }
#pragma warning restore CS8618

    public TEntityId Id { get; set; }
}
