using Dapper;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Application.Exceptions;
using SalaryCalculator.Domain.EmployeeSalaries;
using Throw;

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

    public async Task<Id> AddAsync(EmployeeSalary employeeSalary)
    {
        var addedEntry = await _dbContext.EmployeeSalaries.AddAsync(employeeSalary);

        await _dbContext.SaveChangesAsync();

        return addedEntry.Entity.Id;
    }

    public async Task DeleteAsync(Id employeeSalaryId)
    {
        var target = await GetByIdAsync(employeeSalaryId);

        _dbContext.EmployeeSalaries.Remove(target);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<EmployeeSalary>> GetByDateRangeAsync(Date startDate, Date endDate)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $@"
        select * 
        from EmployeeSalaries 
        where date >= '{startDate.ToInvariantDate()}' 
        and date <= '{endDate.ToInvariantDate()}'";

        var result = await connection.QueryAsync<EmployeeSalary>(sql);

        result.Throw(() => throw new EntryNotFoundException()).IfCountEquals(0);

        return result.ToList();
    }

    public async Task<EmployeeSalary> GetByIdAsync(Id employeeSalaryId)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from EmployeeSalaries where Id = '{employeeSalaryId.Value}'";

        var result = await connection.QuerySingleOrDefaultAsync<EmployeeSalary>(sql);

        result.ThrowIfNull(() => throw new EntryNotFoundException());

        return result;
    }

    public async Task UpdateAsync(Id employeeSalaryId, EmployeeSalary newEmployeeSalary)
    {
        var existing = await GetByIdAsync(employeeSalaryId);

        newEmployeeSalary.Id = existing.Id;

        _dbContext.EmployeeSalaries.Update(newEmployeeSalary);

        await _dbContext.SaveChangesAsync();
    }
}
