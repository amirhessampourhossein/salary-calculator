using SalaryCalculator.Domain.Abstractions;

namespace SalaryCalculator.Domain.EmployeeSalary;

public class EmployeeSalary : Entity<EmployeeSalaryId>
{
    public EmployeeSalary(
        EmployeeSalaryId id,
        FirstName firstName,
        LastName lastName,
        Money basicSalary,
        Money allowance,
        Money transportation,
        DateTime date) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        BasicSalary = basicSalary;
        Allowance = allowance;
        Transportation = transportation;
        Date = date;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Money BasicSalary { get; private set; }
    public Money Allowance { get; private set; }
    public Money Transportation { get; private set; }
    public DateTime Date { get; private set; }
}
