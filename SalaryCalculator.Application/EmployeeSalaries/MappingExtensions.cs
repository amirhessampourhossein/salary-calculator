using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public static class MappingExtensions
{
    public static EmployeeSalaryDto ToDto(this EmployeeSalary employeeSalary)
        => new()
        {
            Id = employeeSalary.Id.Value,
            FirstName = employeeSalary.FirstName.Value,
            LastName = employeeSalary.LastName.Value,
            BasicSalary = employeeSalary.BasicSalary.Amount,
            Allowance = employeeSalary.Allowance.Amount,
            Transportation = employeeSalary.Transportation.Amount,
            Date = employeeSalary.Date.Value
        };

    public static EmployeeSalary ToEntity(this EmployeeSalaryDto employeeSalaryDto)
        => new(new(employeeSalaryDto.Id))
        {
            FirstName = new(employeeSalaryDto.FirstName),
            LastName = new(employeeSalaryDto.LastName),
            BasicSalary = new(employeeSalaryDto.BasicSalary),
            Allowance = new(employeeSalaryDto.Allowance),
            Transportation = new(employeeSalaryDto.Transportation),
            TotalSalary = new(employeeSalaryDto.TotalSalary),
            Date = new(employeeSalaryDto.Date)
        };
}
