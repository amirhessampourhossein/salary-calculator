using SalaryCalculator.Domain.Common;

namespace SalaryCalculator.Domain.EmployeeSalaries;

public class EmployeeSalary : Entity<Id>
{
    public EmployeeSalary(Id id) : base(id)
    {
    }

    public EmployeeSalary()
    {
    }

    public Name FirstName { get; set; } = Name.Empty;
    public Name LastName { get; set; } = Name.Empty;
    public Money BasicSalary { get; set; } = Money.Zero;
    public Money Allowance { get; set; } = Money.Zero;
    public Money Transportation { get; set; } = Money.Zero;
    public Money TotalSalary { get; set; } = Money.Zero;
    public Date Date { get; set; } = Date.MinValue;
}
