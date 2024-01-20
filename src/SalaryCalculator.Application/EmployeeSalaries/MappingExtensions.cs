using SalaryCalculator.Application.Abstractions;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public static class MappingExtensions
{
    public static EmployeeSalaryDto ToDto(this EmployeeSalary employeeSalary, IDateConverter dateConverter) => new()
    {
        Id = employeeSalary.Id.Value,
        FirstName = employeeSalary.FirstName.Value,
        LastName = employeeSalary.LastName.Value,
        BasicSalary = employeeSalary.BasicSalary.Amount,
        Allowance = employeeSalary.Allowance.Amount,
        Transportation = employeeSalary.Transportation.Amount,
        TotalSalary = employeeSalary.TotalSalary.Amount,
        Date = dateConverter.ConvertToPersianDate(employeeSalary.Date.Value)
    };

    public static EmployeeSalary ToEntity(this EmployeeSalaryDto employeeSalaryDto, IDateConverter dateConverter) => new()
    {
        Id = employeeSalaryDto.Id,
        FirstName = employeeSalaryDto.FirstName,
        LastName = employeeSalaryDto.LastName,
        BasicSalary = employeeSalaryDto.BasicSalary,
        Allowance = employeeSalaryDto.Allowance,
        Transportation = employeeSalaryDto.Transportation,
        TotalSalary = employeeSalaryDto.TotalSalary,
        Date = dateConverter.ConvertToGregorianDate(employeeSalaryDto.Date)
    };
}
