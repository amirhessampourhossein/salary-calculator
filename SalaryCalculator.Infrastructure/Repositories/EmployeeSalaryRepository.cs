using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Infrastructure.Repositories;

public class EmployeeSalaryRepository : IEmployeeSalaryRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ISqlConnectionFactory _connectionFactory;

    public EmployeeSalaryRepository(ApplicationDbContext dbContext, ISqlConnectionFactory connectionFactory)
    {
        _dbContext = dbContext;
        _connectionFactory = connectionFactory;
    }

    public async Task<EmployeeSalaryId> AddAsync(EmployeeSalary employeeSalary, CancellationToken cancellationToken = default)
    {
        var added = await _dbContext.EmployeeSalaries.AddAsync(employeeSalary, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return added.Entity.Id;
    }

    public async Task<EmployeeSalaryId?> DeleteAsync(EmployeeSalaryId employeeSalaryId, CancellationToken cancellationToken = default)
    {
        var target = await _dbContext.EmployeeSalaries.FindAsync(
            new object?[] { employeeSalaryId },
            cancellationToken);

        if (target is null)
            return default;

        _dbContext.Remove(target);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return employeeSalaryId;
    }

    public async Task<EmployeeSalary?> GetAsync(EmployeeSalaryId employeeSalaryId, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from dbo.EmployeeSalaries where Id = {employeeSalaryId.Value}";

        return await connection.QuerySingleOrDefaultAsync<EmployeeSalary>(sql);
    }

    public async Task<IReadOnlyList<EmployeeSalary>?> GetRangeAsync(DateRange dateRange, CancellationToken cancellationToken = default)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from dbo.EmployeeSalaries where Date >= {dateRange.Start} and Date <= {dateRange.End}";

        return (await connection.QueryAsync<EmployeeSalary>(sql)).ToList();
    }

    public async Task<EmployeeSalaryId?> UpdateAsync(EmployeeSalaryId employeeSalaryId, EmployeeSalary newEmployeeSalary, CancellationToken cancellationToken = default)
    {
        var target = await _dbContext.EmployeeSalaries.FindAsync(
            new object?[] { employeeSalaryId },
            cancellationToken);

        if (target is null)
            return default;

        _dbContext.Entry(target).CurrentValues.SetValues(newEmployeeSalary);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return employeeSalaryId;
    }
}
