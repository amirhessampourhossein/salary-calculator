using SalaryCalculator.Domain.Common;

namespace SalaryCalculator.Domain.EmployeeSalaries;

public class EmployeeSalary : Entity<EmployeeSalaryId>
{
    public EmployeeSalary(EmployeeSalaryId id) : base(id)
    {
    }

    public EmployeeSalary()
    {
    }

    public FirstName FirstName { get; set; } = FirstName.Empty;
    public LastName LastName { get; set; } = LastName.Empty;
    public Money BasicSalary { get; set; } = Money.Zero;
    public Money Allowance { get; set; } = Money.Zero;
    public Money Transportation { get; set; } = Money.Zero;
    public Money TotalSalary { get; set; } = Money.Zero;
    public Date Date { get; set; } = Date.MinValue;
}
