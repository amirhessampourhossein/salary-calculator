namespace SalaryCalculator.Domain.EmployeeSalaries;

public record FirstName(string Value)
{
    public static FirstName Empty => new(string.Empty);
}