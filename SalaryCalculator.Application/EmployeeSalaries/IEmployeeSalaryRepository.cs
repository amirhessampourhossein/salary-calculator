using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public interface IEmployeeSalaryRepository
{
    Task<EmployeeSalaryId> AddAsync(EmployeeSalary employeeSalary);
    Task UpdateAsync(EmployeeSalary newEmployeeSalary);
    Task DeleteAsync(EmployeeSalary employeeSalary);
    Task<EmployeeSalary?> GetByIdAsync(EmployeeSalaryId employeeSalaryId);
    Task<IReadOnlyList<EmployeeSalary>> GetByDateRangeAsync(Date startDate, Date endDate);
}
