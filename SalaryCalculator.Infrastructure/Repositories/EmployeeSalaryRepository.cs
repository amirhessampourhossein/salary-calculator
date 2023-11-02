using Dapper;
using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Application.EmployeeSalaries;
using SalaryCalculator.Domain.EmployeeSalaries;
using System.Globalization;

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

    public async Task<EmployeeSalaryId> AddAsync(EmployeeSalary employeeSalary)
    {
        var addedEntry = await _dbContext.EmployeeSalaries.AddAsync(employeeSalary);

        await _dbContext.SaveChangesAsync();

        return addedEntry.Entity.Id;
    }

    public async Task DeleteAsync(EmployeeSalary employeeSalary)
    {
        _dbContext.EmployeeSalaries.Remove(employeeSalary!);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<EmployeeSalary>> GetByDateRangeAsync(Date startDate, Date endDate)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $@"
        select * 
        from dbo.EmployeeSalaries 
        where date >= '{startDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}' 
        and date <= '{endDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}'";

        return (await connection.QueryAsync<EmployeeSalaryResponse>(sql))
            .Select(dto => dto.ToEntity())
            .ToList();
    }

    public async Task<EmployeeSalary?> GetByIdAsync(EmployeeSalaryId employeeSalaryId)
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"select * from dbo.EmployeeSalaries where Id = '{employeeSalaryId.Value}'";

        return (await connection.QuerySingleOrDefaultAsync<EmployeeSalaryResponse>(sql))?.ToEntity();
    }

    public async Task UpdateAsync(EmployeeSalary newEmployeeSalary)
    {
        _dbContext.EmployeeSalaries.Update(newEmployeeSalary);

        await _dbContext.SaveChangesAsync();
    }
}
