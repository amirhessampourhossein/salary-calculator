using OvertimePolicies;
using SalaryCalculator.Domain.EmployeeSalaries;

namespace SalaryCalculator.Application.EmployeeSalaries;

public static class OvertimeService
{
    public static Money? CalculateOvertime(EmployeeSalary employeeSalary, string overtimeCalculator)
    {
        return overtimeCalculator.Trim().ToLower() switch
        {
            "calculatea" => new(OvertimeMethods.CalculateA(employeeSalary.BasicSalary.Amount, employeeSalary.Allowance.Amount)),
            "calculateb" => new(OvertimeMethods.CalculateB(employeeSalary.BasicSalary.Amount, employeeSalary.Allowance.Amount)),
            "calculatec" => new(OvertimeMethods.CalculateC(employeeSalary.BasicSalary.Amount, employeeSalary.Allowance.Amount)),
            _ => null
        };
    }
}
