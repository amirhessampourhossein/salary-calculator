using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.Common;

namespace SalaryCalculator.Application.Abstractions;

public interface IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
{
    Task<TEntityId> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default);

    Task<TEntityId?> DeleteAsync(
        TEntityId entityId,
        CancellationToken cancellationToken = default);

    Task<TEntityId?> UpdateAsync(
        TEntityId entityId,
        TEntity newEntity,
        CancellationToken cancellationToken = default);

    Task<TEntity?> GetAsync(
        TEntityId entityId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>> GetRangeAsync(
        DateRange dateRange,
        CancellationToken cancellationToken = default);
}
