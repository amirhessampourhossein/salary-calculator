namespace SalaryCalculator.Domain.Common;

public abstract class Entity<TEntityId>
{
    protected Entity(TEntityId id)
    {
        Id = id;
    }

    public TEntityId Id { get; init; }
}
