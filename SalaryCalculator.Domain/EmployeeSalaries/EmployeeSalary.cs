using SalaryCalculator.Domain.Common;

namespace SalaryCalculator.Domain.EmployeeSalaries;

public class EmployeeSalary : Entity<Id>
{
    public Name FirstName { get; set; } = string.Empty;
    public Name LastName { get; set; } = string.Empty;
    public Money BasicSalary { get; set; } = 0;
    public Money Allowance { get; set; } = 0;
    public Money Transportation { get; set; } = 0;
    public Money TotalSalary { get; set; } = 0;
    public Date Date { get; set; } = DateOnly.MinValue;
}
