using SalaryCalculator.Application.Models;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public interface IEmployeeSalaryRepository
{
    Task<EmployeeSalaryId> AddAsync(
        EmployeeSalary employeeSalary,
        CancellationToken cancellationToken = default);

    Task<EmployeeSalaryId?> UpdateAsync(
        EmployeeSalaryId employeeSalaryId,
        EmployeeSalary newEmployeeSalary,
        CancellationToken cancellationToken = default);

    Task<EmployeeSalaryId?> DeleteAsync(
        EmployeeSalaryId employeeSalaryId,
        CancellationToken cancellationToken = default);

    Task<EmployeeSalary?> GetAsync(
        EmployeeSalaryId employeeSalaryId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<EmployeeSalary>?> GetRangeAsync(
        DateRange dateRange,
        CancellationToken cancellationToken = default);
}
