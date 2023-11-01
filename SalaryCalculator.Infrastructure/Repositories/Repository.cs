using Dapper;
using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.Common;

namespace SalaryCalculator.Infrastructure.Repositories;

public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ISqlConnectionFactory _connectionFactory;

    public Repository(ApplicationDbContext dbContext, ISqlConnectionFactory connectionFactory)
    {
        _dbContext = dbContext;
        _connectionFactory = connectionFactory;
    }

    public async Task<TEntityId> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var added = await _dbContext
            .Set<TEntity>()
            .AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return added.Entity.Id;
    }

    public async Task<TEntityId?> DeleteAsync(TEntityId entityId, CancellationToken cancellationToken = default)
    {
        var target = await _dbContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(entity => entity.Id == entityId, cancellationToken);

        if (target is null)
            return default;

        _dbContext.Remove(target);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entityId;
    }

    public async Task<TEntity?> GetAsync(TEntityId entityId, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from dbo.EmployeeSalaries where Id = {entityId}";

        return await connection.QuerySingleOrDefaultAsync<TEntity>(sql);
    }

    public async Task<IReadOnlyList<TEntity>> GetRangeAsync(DateRange dateRange, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from dbo.EmployeeSalaries where Date >= {dateRange.Start} and Date <= {dateRange.End}";

        return (await connection.QueryAsync<TEntity>(sql)).ToList();
    }

    public async Task<TEntityId?> UpdateAsync(TEntityId entityId, TEntity newEntity, CancellationToken cancellationToken = default)
    {
        var target = await _dbContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(entity => entity.Id == entityId, cancellationToken);

        if (target is null)
            return default;

        _dbContext.Entry(target).CurrentValues.SetValues(newEntity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entityId;
    }
}
