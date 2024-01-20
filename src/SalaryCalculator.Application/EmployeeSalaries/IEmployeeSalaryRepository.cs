using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public interface IEmployeeSalaryRepository
{
    Task<Id> AddAsync(EmployeeSalary employeeSalary);
    Task UpdateAsync(Id employeeSalaryId, EmployeeSalary newEmployeeSalary);
    Task DeleteAsync(Id employeeSalaryId);
    Task<EmployeeSalary> GetByIdAsync(Id employeeSalaryId);
    Task<IReadOnlyList<EmployeeSalary>> GetByDateRangeAsync(Date startDate, Date endDate);
}
