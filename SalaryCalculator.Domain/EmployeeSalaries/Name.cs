namespace SalaryCalculator.Domain.EmployeeSalaries;

public record Name(string? Value)
{
    public static Name Empty => new(string.Empty);
}