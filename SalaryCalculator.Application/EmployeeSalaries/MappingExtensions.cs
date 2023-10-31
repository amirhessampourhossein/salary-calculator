using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public static class MappingExtensions
{
    public static EmployeeSalaryDto ToDto(this EmployeeSalary employeeSalary)
        => new()
        {
            FirstName = employeeSalary.FirstName.Value,
            LastName = employeeSalary.LastName.Value,
            BasicSalary = employeeSalary.BasicSalary.Amount,
            Allowance = employeeSalary.Allowance.Amount,
            Transportation = employeeSalary.Transportation.Amount,
            Date = employeeSalary.Date
        };
}
